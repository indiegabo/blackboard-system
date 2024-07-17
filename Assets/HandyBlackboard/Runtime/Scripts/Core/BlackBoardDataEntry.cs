
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGabo.HandyBlackboard
{
    [System.Serializable]
    public class BlackBoardDataEntry
    {
        public string keyName;
        public BlackboardValueType valueType;
        public AnyValue value = new();

        public void SetValuesOnBlackboard(Blackboard blackboard)
        {
            var key = blackboard.GetOrRegisterKey(keyName);
            setValueDispatchTable[valueType](blackboard, key, value);
        }

        static Dictionary<
            BlackboardValueType,
            Action<Blackboard, BlackboardKey, AnyValue>
        > setValueDispatchTable = new()
        {
            { BlackboardValueType.Bool, (blackboard, key, value) => blackboard.SetValue(key, value.boolValue) },
            { BlackboardValueType.String, (blackboard, key, value) => blackboard.SetValue(key, value.stringValue) },
            { BlackboardValueType.Int, (blackboard, key, value) => blackboard.SetValue(key, value.intValue) },
            { BlackboardValueType.Curve, (blackboard, key, value) => blackboard.SetValue(key, value.curveValue) },
            { BlackboardValueType.Float, (blackboard, key, value) => blackboard.SetValue(key, value.floatValue) },
            { BlackboardValueType.Object, (blackboard, key, value) => blackboard.SetValue(key, value.objectValue) },
            { BlackboardValueType.Vector2, (blackboard, key, value) => blackboard.SetValue(key, value.vector2Value) },
            { BlackboardValueType.Vector3, (blackboard, key, value) => blackboard.SetValue(key, value.vector3Value) },
            { BlackboardValueType.Color, (blackboard, key, value) => blackboard.SetValue(key, value.colorValue) },
            { BlackboardValueType.Gradient, (blackboard, key, value) => blackboard.SetValue(key, value.gradientValue) },
            { BlackboardValueType.LayerMask, (blackboard, key, value) => blackboard.SetValue(key, value.layerMaskValue) },
            { BlackboardValueType.Tag, (blackboard, key, value) => blackboard.SetValue(key, value.tagValue) },
            { BlackboardValueType.Rect, (blackboard, key, value) => blackboard.SetValue(key, value.rectValue) },
            { BlackboardValueType.Bounds, (blackboard, key, value) => blackboard.SetValue(key, value.boundsValue) },
            { BlackboardValueType.Long, (blackboard, key, value) => blackboard.SetValue(key, value.longValue) },
            { BlackboardValueType.Double, (blackboard, key, value) => blackboard.SetValue(key, value.doubleValue) },
            { BlackboardValueType.Vector2Int, (blackboard, key, value) => blackboard.SetValue(key, value.vector2IntValue) },
            { BlackboardValueType.Vector3Int, (blackboard, key, value) => blackboard.SetValue(key, value.vector3IntValue) },
            { BlackboardValueType.RectInt, (blackboard, key, value) => blackboard.SetValue(key, value.rectIntValue) },
            { BlackboardValueType.Hash128, (blackboard, key, value) => blackboard.SetValue(key, value.hash128Value) },
            { BlackboardValueType.Vector4, (blackboard, key, value) => blackboard.SetValue(key, value.vector4Value) },
            { BlackboardValueType.Mask, (blackboard, key, value) => blackboard.SetValue(key, value.maskValue) },
            { BlackboardValueType.Layer, (blackboard, key, value) => blackboard.SetValue(key, value.layerValue) },
        };

    }
}