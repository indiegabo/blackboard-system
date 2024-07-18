using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace IndieGabo.HandyBlackboard
{

    [Serializable]
    public class BlackboardEntry { }

    [Serializable]
    public class BlackboardEntry<T> : BlackboardEntry
    {
        public BlackboardKey Key { get; }
        public T Value { get; set; }
        public Type SystemType { get; }


        public BlackboardEntry(BlackboardKey key, T value)
        {
            Key = key;
            Value = value;
            SystemType = typeof(T);
        }

        public override bool Equals(object obj) => obj is BlackboardEntry<T> other && other.Key == Key;
        public override int GetHashCode() => Key.GetHashCode();
    }
}