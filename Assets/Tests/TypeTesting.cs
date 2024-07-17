using IndieGabo.HandyBlackboard;
using UnityEngine;

public class TypeTesting : MonoBehaviour
{
    public BlackboardData _data;
    private Blackboard _blackboard;

    private void Awake()
    {
        _blackboard = new Blackboard();
        _data.SetValuesOnBlackboard(_blackboard);

        BlackboardKey intKey = _blackboard.GetOrRegisterKey("intKey");
        BlackboardKey floatKey = _blackboard.GetOrRegisterKey("floatKey");

        if (_blackboard.TryGetValue(intKey, out int value1))
        {
            Debug.Log(value1);
        }

        _blackboard.SetValue(intKey, 5);

        if (_blackboard.TryGetValue(intKey, out int value2))
        {
            Debug.Log(value2);
        }

        if (_blackboard.TryGetValue(floatKey, out float value3))
        {
            Debug.Log(value3);
        }

        _blackboard.SetValue(floatKey, 5.5f);

        if (_blackboard.TryGetValue(floatKey, out float value4))
        {
            Debug.Log(value4);
        }
    }
}