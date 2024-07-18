using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace IndieGabo.HandyBlackboard
{
    [System.Serializable]
    public class Blackboard
    {
        protected Dictionary<string, BlackboardKey> _keyRegistry = new();
        protected Dictionary<BlackboardKey, object> _entries = new();

        public void DebugAll()
        {
            foreach (var pair in _entries)
            {
                LogEntry(pair.Key, pair.Value);
            }
        }

        public void Debug(string keyName)
        {
            BlackboardKey key = GetOrRegisterKey(keyName);
            Debug(key);
        }

        public void Debug(BlackboardKey key)
        {
            if (!_entries.TryGetValue(key, out object entry))
            {
                UnityEngine.Debug.LogWarning($"Trying to debug {key.Name} but it doesn't exist");
                return;
            }

            LogEntry(key, entry);
        }

        private void LogEntry(BlackboardKey key, object entry)
        {
            var entryType = entry.GetType();

            if (entryType.IsGenericType && entryType.GetGenericTypeDefinition() == typeof(BlackboardEntry<>))
            {
                var valueProperty = entryType.GetProperty("Value");

                if (valueProperty == null)
                {
                    return;
                }

                var value = valueProperty.GetValue(entry);
                UnityEngine.Debug.Log($"Blackboard Entry <b>{key.Name}</b>: | {value} | {value.GetType()}");
            }
        }

        public bool TryGetValue<T>(BlackboardKey key, out T value)
        {
            if (_entries.TryGetValue(key, out object entry) && entry is BlackboardEntry<T> castedEntry)
            {
                value = castedEntry.Value;
                return true;
            }

            value = default;
            return false;
        }

        public void SetValue<T>(BlackboardKey key, T value)
        {
            if (_entries.TryGetValue(key, out object entry) && entry is BlackboardEntry<T> castedEntry)
            {
                castedEntry.Value = value;
                return;
            }

            _entries[key] = new BlackboardEntry<T>(key, value);
        }

        public BlackboardKey GetOrRegisterKey(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException(nameof(name));
            }

            if (!_keyRegistry.TryGetValue(name, out BlackboardKey key))
            {
                key = new BlackboardKey(name);
                _keyRegistry.Add(name, key);
            }

            return key;
        }

        public bool ContainsKey(string name) => _keyRegistry.ContainsKey(name);
        public bool ContainsKey(BlackboardKey key) => _entries.ContainsKey(key);
    }
}