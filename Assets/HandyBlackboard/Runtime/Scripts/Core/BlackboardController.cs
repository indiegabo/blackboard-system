using UnityEngine;

namespace IndieGabo.HandyBlackboard
{
    public class BlackboardController : MonoBehaviour
    {
        [SerializeField]
        private BlackboardData _initialData;

        private Blackboard _blackboard = new();


    }
}