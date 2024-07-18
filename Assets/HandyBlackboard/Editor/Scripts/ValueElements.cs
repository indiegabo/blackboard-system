using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace IndieGabo.HandyBlackboard.Editor
{
    public static class ValueElements
    {
        public static Toggle GenerateBoolField(bool initialValue, UnityAction<bool> onValueChanged = null)
        {
            Toggle toggle = new() { value = initialValue };
            if (onValueChanged != null)
                toggle.RegisterValueChangedCallback(evt => onValueChanged.Invoke(evt.newValue));
            return toggle;
        }

        public static TextField GenerateStringField(string initialValue, UnityAction<string> onValueChanged)
        {
            TextField textField = new() { value = initialValue };
            if (onValueChanged != null)
                textField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return textField;
        }

        public static IntegerField GenerateIntField(int initialValue, UnityAction<int> onValueChanged)
        {
            IntegerField textField = new() { value = initialValue };
            if (onValueChanged != null)
                textField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return textField;
        }

        public static FloatField GenerateFloatField(float initialValue, UnityAction<float> onValueChanged)
        {
            FloatField textField = new() { value = initialValue };
            if (onValueChanged != null)
                textField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return textField;
        }

        public static ObjectField GenerateObjectField(Object initialValue, UnityAction<Object> onValueChanged)
        {
            ObjectField objectField = new() { value = initialValue };
            if (onValueChanged != null)
                objectField.RegisterValueChangedCallback(evt =>
                {
                    onValueChanged?.Invoke(evt.newValue);
                });
            return objectField;
        }

        public static ObjectField GenerateTransformField(Transform initialValue, UnityAction<Transform> onValueChanged)
        {
            ObjectField objectField = new()
            {
                value = initialValue,
                objectType = typeof(Transform)
            };

            if (onValueChanged != null)
                objectField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue as Transform));
            return objectField;
        }

        public static Vector2Field GenerateVector2Field(Vector2 initialValue, UnityAction<Vector2> onValueChanged)
        {
            Vector2Field vector2Field = new() { value = initialValue };
            if (onValueChanged != null)
                vector2Field.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return vector2Field;
        }

        public static Vector3Field GenerateVector3Field(Vector3 initialValue, UnityAction<Vector3> onValueChanged)
        {
            Vector3Field vector3Field = new() { value = initialValue };
            if (onValueChanged != null)
                vector3Field.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return vector3Field;
        }

        public static ColorField GenerateColorField(Color initialValue, UnityAction<Color> onValueChanged)
        {
            ColorField colorField = new() { value = initialValue };
            if (onValueChanged != null)
                colorField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return colorField;
        }

        public static CurveField GenerateCurveField(AnimationCurve initialValue, UnityAction<AnimationCurve> onValueChanged)
        {
            CurveField curveField = new() { value = initialValue };
            if (onValueChanged != null)
                curveField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return curveField;
        }

        public static GradientField GenerateGradientField(Gradient initialValue, UnityAction<Gradient> onValueChanged)
        {
            GradientField gradientField = new() { value = initialValue };
            if (onValueChanged != null)
                gradientField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return gradientField;
        }

        public static LayerMaskField GenerateLayerMaskField(LayerMask initialValue, UnityAction<LayerMask> onValueChanged)
        {
            LayerMaskField layerMaskField = new() { value = initialValue };
            if (onValueChanged != null)
                layerMaskField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return layerMaskField;
        }

        public static TagField GenerateTagField(string initialValue, UnityAction<string> onValueChanged)
        {
            TagField tagField = new() { value = initialValue };
            if (onValueChanged != null)
                tagField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return tagField;
        }

        public static RectField GenerateRectField(Rect initialValue, UnityAction<Rect> onValueChanged)
        {
            RectField rectField = new() { value = initialValue };
            if (onValueChanged != null)
                rectField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return rectField;
        }

        public static BoundsField GenerateBoundsField(Bounds initialValue, UnityAction<Bounds> onValueChanged)
        {
            BoundsField boundsField = new() { value = initialValue };
            if (onValueChanged != null)
                boundsField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return boundsField;
        }

        public static LongField GenerateLongField(long initialValue, UnityAction<long> onValueChanged)
        {
            LongField longField = new() { value = initialValue };
            if (onValueChanged != null)
                longField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return longField;
        }

        public static DoubleField GenerateDoubleField(double initialValue, UnityAction<double> onValueChanged)
        {
            DoubleField doubleField = new() { value = initialValue };
            if (onValueChanged != null)
                doubleField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return doubleField;
        }

        public static Vector2IntField GenerateVector2IntField(Vector2Int initialValue, UnityAction<Vector2Int> onValueChanged)
        {
            Vector2IntField vector2IntField = new() { value = initialValue };
            if (onValueChanged != null)
                vector2IntField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return vector2IntField;
        }

        public static Vector3IntField GenerateVector3IntField(Vector3Int initialValue, UnityAction<Vector3Int> onValueChanged)
        {
            Vector3IntField vector3IntField = new() { value = initialValue };
            if (onValueChanged != null)
                vector3IntField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return vector3IntField;
        }

        public static RectIntField GenerateRectIntField(RectInt initialValue, UnityAction<RectInt> onValueChanged)
        {
            RectIntField rectIntField = new() { value = initialValue };
            if (onValueChanged != null)
                rectIntField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return rectIntField;
        }

        public static Hash128Field GenerateHash128Field(Hash128 initialValue, UnityAction<Hash128> onValueChanged)
        {
            Hash128Field hash128Field = new() { value = initialValue };
            if (onValueChanged != null)
                hash128Field.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return hash128Field;
        }

        public static Vector4Field GenerateVector4Field(Vector4 initialValue, UnityAction<Vector4> onValueChanged)
        {
            Vector4Field vector4Field = new() { value = initialValue };
            if (onValueChanged != null)
                vector4Field.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return vector4Field;
        }

        public static MaskField GenerateMaskField(int initialValue, UnityAction<int> onValueChanged)
        {
            MaskField maskField = new() { value = initialValue };
            if (onValueChanged != null)
                maskField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return maskField;
        }

        public static LayerField GenerateLayerField(int initialValue, UnityAction<int> onValueChanged)
        {
            LayerField layerField = new() { value = initialValue };
            if (onValueChanged != null)
                layerField.RegisterValueChangedCallback(evt => onValueChanged?.Invoke(evt.newValue));
            return layerField;
        }
    }
}