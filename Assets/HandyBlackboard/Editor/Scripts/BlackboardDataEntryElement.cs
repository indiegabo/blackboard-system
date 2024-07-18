using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace IndieGabo.HandyBlackboard.Editor
{
    public class BlackboardDataEntryElement : VisualElement
    {
        private const string TemplateName = "BlackboardDataEntryElement";

        private TemplateContainer _containerMain;

        private VisualElement _containerValue;
        private TextField _fieldKey;
        private EnumField _fieldType;

        private BlackBoardDataEntry _entry;

        public BlackboardDataEntryElement()
        {
            _containerMain = Resources.Load<VisualTreeAsset>($"UXML/{TemplateName}").CloneTree();

            _fieldKey = _containerMain.Q<TextField>("field-key");
            _fieldKey.RegisterValueChangedCallback(evt => _entry.keyName = evt.newValue);

            _fieldType = _containerMain.Q<EnumField>("field-type");
            _fieldType.RegisterValueChangedCallback(evt =>
            {
                _entry.valueType = (BlackboardValueType)evt.newValue;
                EvaluateAndSetFieldElement(_entry.valueType);
            });

            _containerValue = _containerMain.Q<VisualElement>("container-value");
            Add(_containerMain);
        }

        public void SetEntry(BlackBoardDataEntry entry)
        {
            _entry = entry;
            _fieldKey.value = _entry.keyName;
            _fieldType.value = _entry.valueType;
            EvaluateAndSetFieldElement(_entry.valueType);
        }

        private void SetValueField(VisualElement fieldElement)
        {
            _containerValue.Clear();
            _containerValue.Add(fieldElement);
        }

        public void EvaluateAndSetFieldElement(BlackboardValueType type)
        {
            VisualElement fieldElement = type switch
            {
                BlackboardValueType.Bool => ValueElements.GenerateBoolField(_entry.value.boolValue, newValue => _entry.value.boolValue = newValue),
                BlackboardValueType.String => ValueElements.GenerateStringField(_entry.value.stringValue, newValue => _entry.value.stringValue = newValue),
                BlackboardValueType.Int => ValueElements.GenerateIntField(_entry.value.intValue, newValue => _entry.value.intValue = newValue),
                BlackboardValueType.Float => ValueElements.GenerateFloatField(_entry.value.floatValue, newValue => _entry.value.floatValue = newValue),
                BlackboardValueType.Object => ValueElements.GenerateObjectField(_entry.value.objectValue, newValue => _entry.value.objectValue = newValue),
                BlackboardValueType.Transform => ValueElements.GenerateTransformField(_entry.value.transformValue, newValue => _entry.value.transformValue = newValue),
                BlackboardValueType.Vector2 => ValueElements.GenerateVector2Field(_entry.value.vector2Value, newValue => _entry.value.vector2Value = newValue),
                BlackboardValueType.Vector3 => ValueElements.GenerateVector3Field(_entry.value.vector3Value, newValue => _entry.value.vector3Value = newValue),
                BlackboardValueType.Color => ValueElements.GenerateColorField(_entry.value.colorValue, newValue => _entry.value.colorValue = newValue),
                BlackboardValueType.Gradient => ValueElements.GenerateGradientField(_entry.value.gradientValue, newValue => _entry.value.gradientValue = newValue),
                BlackboardValueType.Curve => ValueElements.GenerateCurveField(_entry.value.curveValue, newValue => _entry.value.curveValue = newValue),
                BlackboardValueType.LayerMask => ValueElements.GenerateLayerMaskField(_entry.value.layerMaskValue, newValue => _entry.value.layerMaskValue = newValue),
                BlackboardValueType.Tag => ValueElements.GenerateTagField(_entry.value.tagValue, newValue => _entry.value.tagValue = newValue),
                BlackboardValueType.Rect => ValueElements.GenerateRectField(_entry.value.rectValue, newValue => _entry.value.rectValue = newValue),
                BlackboardValueType.Bounds => ValueElements.GenerateBoundsField(_entry.value.boundsValue, newValue => _entry.value.boundsValue = newValue),
                BlackboardValueType.Long => ValueElements.GenerateLongField(_entry.value.longValue, newValue => _entry.value.longValue = newValue),
                BlackboardValueType.Double => ValueElements.GenerateDoubleField(_entry.value.doubleValue, newValue => _entry.value.doubleValue = newValue),
                BlackboardValueType.Vector2Int => ValueElements.GenerateVector2IntField(_entry.value.vector2IntValue, newValue => _entry.value.vector2IntValue = newValue),
                BlackboardValueType.Vector3Int => ValueElements.GenerateVector3IntField(_entry.value.vector3IntValue, newValue => _entry.value.vector3IntValue = newValue),
                BlackboardValueType.RectInt => ValueElements.GenerateRectIntField(_entry.value.rectIntValue, newValue => _entry.value.rectIntValue = newValue),
                BlackboardValueType.Hash128 => ValueElements.GenerateHash128Field(_entry.value.hash128Value, newValue => _entry.value.hash128Value = newValue),
                BlackboardValueType.Vector4 => ValueElements.GenerateVector4Field(_entry.value.vector4Value, newValue => _entry.value.vector4Value = newValue),
                BlackboardValueType.Mask => ValueElements.GenerateMaskField(_entry.value.maskValue, newValue => _entry.value.maskValue = newValue),
                BlackboardValueType.Layer => ValueElements.GenerateLayerField(_entry.value.layerValue, newValue => _entry.value.layerValue = newValue),
                _ => throw new System.NotSupportedException($"Value type {type} is not supported")
            };

            SetValueField(fieldElement);
        }

    }
}