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

        public void Debug()
        {
            foreach (var entry in _entries)
            {
                var entryType = entry.Value.GetType();

                if (entryType.IsGenericType && entryType.GetGenericTypeDefinition() == typeof(BlackboardEntry<>))
                {
                    var valueProperty = entryType.GetProperty("Value");

                    if (valueProperty == null) continue;

                    var value = valueProperty.GetValue(entry.Value);
                    UnityEngine.Debug.Log($"{entry.Key.Name}: {value}");
                }
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
            _entries[key] = new BlackboardEntry<T>(key, value);
        }

        public void RegisterEntry<T>(BlackboardKey key, BlackboardEntry<T> entry)
        {
            _entries[key] = entry;
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