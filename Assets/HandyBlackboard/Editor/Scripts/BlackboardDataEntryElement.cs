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
                BlackboardValueType.Bool => GenerateBoolField(),
                BlackboardValueType.String => GenerateStringField(),
                BlackboardValueType.Int => GenerateIntField(),
                BlackboardValueType.Float => GenerateFloatField(),
                BlackboardValueType.Object => GenerateObjectField(),
                BlackboardValueType.Vector2 => GenerateVector2Field(),
                BlackboardValueType.Vector3 => GenerateVector3Field(),
                BlackboardValueType.Color => GenerateColorField(),
                BlackboardValueType.Gradient => GenerateGradientField(),
                BlackboardValueType.Curve => GenerateCurveField(),
                BlackboardValueType.LayerMask => GenerateLayerMaskField(),
                BlackboardValueType.Tag => GenerateTagField(),
                BlackboardValueType.Rect => GenerateRectField(),
                BlackboardValueType.Bounds => GenerateBoundsField(),
                BlackboardValueType.Long => GenerateLongField(),
                BlackboardValueType.Double => GenerateDoubleField(),
                BlackboardValueType.Vector2Int => GenerateVector2IntField(),
                BlackboardValueType.Vector3Int => GenerateVector3IntField(),
                BlackboardValueType.RectInt => GenerateRectIntField(),
                BlackboardValueType.Hash128 => GenerateHash128Field(),
                BlackboardValueType.Vector4 => GenerateVector4Field(),
                BlackboardValueType.Mask => GenerateMaskField(),
                BlackboardValueType.Layer => GenerateLayerField(),
                _ => throw new System.NotSupportedException($"Value type {type} is not supported")
            };

            SetValueField(fieldElement);
        }

        private Toggle GenerateBoolField()
        {
            Toggle toggle = new() { value = _entry.value.boolValue };
            toggle.RegisterValueChangedCallback(evt => _entry.value.boolValue = evt.newValue);
            return toggle;
        }

        private TextField GenerateStringField()
        {
            TextField textField = new() { value = _entry.value.stringValue };
            textField.RegisterValueChangedCallback(evt => _entry.value.stringValue = evt.newValue);
            return textField;
        }

        private IntegerField GenerateIntField()
        {
            IntegerField intField = new() { value = _entry.value.intValue };
            intField.RegisterValueChangedCallback(evt => _entry.value.intValue = evt.newValue);
            return intField;
        }

        private FloatField GenerateFloatField()
        {
            FloatField floatField = new() { value = _entry.value.floatValue };
            floatField.RegisterValueChangedCallback(evt => _entry.value.floatValue = evt.newValue);
            return floatField;
        }

        private ObjectField GenerateObjectField()
        {
            ObjectField objectField = new() { value = _entry.value.objectValue };
            objectField.RegisterValueChangedCallback(evt =>
            {
                _entry.value.objectValue = evt.newValue;
            });
            return objectField;
        }

        private Vector2Field GenerateVector2Field()
        {
            Vector2Field vector2Field = new() { value = _entry.value.vector2Value };
            vector2Field.RegisterValueChangedCallback(evt => _entry.value.vector2Value = evt.newValue);
            return vector2Field;
        }

        private Vector3Field GenerateVector3Field()
        {
            Vector3Field vector3Field = new() { value = _entry.value.vector3Value };
            vector3Field.RegisterValueChangedCallback(evt => _entry.value.vector3Value = evt.newValue);
            return vector3Field;
        }

        private ColorField GenerateColorField()
        {
            ColorField colorField = new() { value = _entry.value.colorValue };
            colorField.RegisterValueChangedCallback(evt => _entry.value.colorValue = evt.newValue);
            return colorField;
        }

        private GradientField GenerateGradientField()
        {
            GradientField gradientField = new() { value = _entry.value.gradientValue };
            gradientField.RegisterValueChangedCallback(evt => _entry.value.gradientValue = evt.newValue);
            return gradientField;
        }

        private CurveField GenerateCurveField()
        {
            CurveField curveField = new() { value = _entry.value.curveValue };
            curveField.RegisterValueChangedCallback(evt => _entry.value.curveValue = evt.newValue);
            return curveField;
        }

        private LayerMaskField GenerateLayerMaskField()
        {
            LayerMaskField layerMaskField = new() { value = _entry.value.layerMaskValue };
            layerMaskField.RegisterValueChangedCallback(evt => _entry.value.layerMaskValue = evt.newValue);
            return layerMaskField;
        }

        private TagField GenerateTagField()
        {
            TagField tagField = new() { value = _entry.value.tagValue };
            tagField.RegisterValueChangedCallback(evt => _entry.value.tagValue = evt.newValue);
            return tagField;
        }

        private RectField GenerateRectField()
        {
            RectField rectField = new() { value = _entry.value.rectValue };
            rectField.RegisterValueChangedCallback(evt => _entry.value.rectValue = evt.newValue);
            return rectField;
        }

        private BoundsField GenerateBoundsField()
        {
            BoundsField boundsField = new() { value = _entry.value.boundsValue };
            boundsField.RegisterValueChangedCallback(evt => _entry.value.boundsValue = evt.newValue);
            return boundsField;
        }

        private LongField GenerateLongField()
        {
            LongField longField = new() { value = _entry.value.longValue };
            longField.RegisterValueChangedCallback(evt => _entry.value.longValue = evt.newValue);
            return longField;
        }

        private DoubleField GenerateDoubleField()
        {
            DoubleField doubleField = new() { value = _entry.value.doubleValue };
            doubleField.RegisterValueChangedCallback(evt => _entry.value.doubleValue = evt.newValue);
            return doubleField;
        }

        private Vector2IntField GenerateVector2IntField()
        {
            Vector2IntField vector2IntField = new() { value = _entry.value.vector2IntValue };
            vector2IntField.RegisterValueChangedCallback(evt => _entry.value.vector2IntValue = evt.newValue);
            return vector2IntField;
        }

        private Vector3IntField GenerateVector3IntField()
        {
            Vector3IntField vector3IntField = new() { value = _entry.value.vector3IntValue };
            vector3IntField.RegisterValueChangedCallback(evt => _entry.value.vector3IntValue = evt.newValue);
            return vector3IntField;
        }

        private RectIntField GenerateRectIntField()
        {
            RectIntField rectIntField = new() { value = _entry.value.rectIntValue };
            rectIntField.RegisterValueChangedCallback(evt => _entry.value.rectIntValue = evt.newValue);
            return rectIntField;
        }

        private Hash128Field GenerateHash128Field()
        {
            Hash128Field hash128Field = new() { value = _entry.value.hash128Value };
            hash128Field.RegisterValueChangedCallback(evt => _entry.value.hash128Value = evt.newValue);
            return hash128Field;
        }

        private Vector4Field GenerateVector4Field()
        {
            Vector4Field vector4Field = new() { value = _entry.value.vector4Value };
            vector4Field.RegisterValueChangedCallback(evt => _entry.value.vector4Value = evt.newValue);
            return vector4Field;
        }

        private MaskField GenerateMaskField()
        {
            MaskField maskField = new() { value = _entry.value.maskValue };
            maskField.RegisterValueChangedCallback(evt => _entry.value.maskValue = evt.newValue);
            return maskField;
        }

        private LayerField GenerateLayerField()
        {
            LayerField layerField = new() { value = _entry.value.layerValue };
            layerField.RegisterValueChangedCallback(evt => _entry.value.layerValue = evt.newValue);
            return layerField;
        }

    }
}