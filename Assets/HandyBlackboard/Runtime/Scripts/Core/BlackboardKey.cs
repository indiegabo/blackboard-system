using System;
using UnityEngine;

namespace IndieGabo.HandyBlackboard
{
    [System.Serializable]
    public struct BlackboardKey : IEquatable<BlackboardKey>
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private int _hashedKey;

        public string Name => _name;
        public int HashedKey => _hashedKey;

        public BlackboardKey(string name)
        {
            _name = name;
            _hashedKey = name.ComputeFNV1aHash();
        }

        public readonly bool Equals(BlackboardKey other) => _hashedKey == other.HashedKey;
        public override readonly bool Equals(object obj) => obj is BlackboardKey other && Equals(other);
        public override readonly int GetHashCode() => _hashedKey;

        public override readonly string ToString() => $"BlackboardKey: {_name}";

        public static bool operator ==(BlackboardKey left, BlackboardKey right) => left.HashedKey == right.HashedKey;
        public static bool operator !=(BlackboardKey left, BlackboardKey right) => !(left == right);

    }
}