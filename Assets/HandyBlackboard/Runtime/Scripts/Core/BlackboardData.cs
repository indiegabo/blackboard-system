using System.Collections.Generic;
using UnityEngine;

namespace IndieGabo.HandyBlackboard
{
    [CreateAssetMenu(fileName = "Blackboard Data", menuName = "IndieGabo/Handy Blackboard/BlackboardData", order = 0)]
    public class BlackboardData : ScriptableObject
    {
        [SerializeField]
        private List<BlackBoardDataEntry> _entries = new();


        public List<BlackBoardDataEntry> Entries => _entries;

        public void SetValuesOnBlackboard(Blackboard blackboard)
        {
            foreach (var dataEntry in _entries)
            {
                dataEntry.SetValuesOnBlackboard(blackboard);
            }
        }
    }
}