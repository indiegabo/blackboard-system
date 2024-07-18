using System.Collections.Generic;
using UnityEngine;

namespace IndieGabo.HandyBlackboard
{
    [DefaultExecutionOrder(1)]
    public class BlackboardBehaviour : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        protected BlackboardData _data;

        #endregion

        #region Fields

        protected Blackboard _blackboard = new();

        #endregion

        #region Getters

        public Blackboard Blackboard => _blackboard;

        #endregion

        #region Behaviour

        private void Awake()
        {
            _data.SetValuesOnBlackboard(_blackboard);
        }

        #endregion

        #region Handling

        public BlackboardKey GetOrRegisterKey(string name)
        {
            return _blackboard.GetOrRegisterKey(name);
        }

        public bool TryGetValue<T>(string keyName, out T value)
        {
            return _blackboard.TryGetValue(GetOrRegisterKey(keyName), out value);
        }

        public bool TryGetValue<T>(BlackboardKey key, out T value)
        {
            return _blackboard.TryGetValue(key, out value);
        }

        public void SetValue<T>(BlackboardKey key, T value)
        {
            _blackboard.SetValue(key, value);
        }

        #endregion
    }
}