using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace IndieGabo.HandyBlackboard
{
    [System.Serializable]
    public class AnyValue
    {
        public BlackboardValueType type;

        public bool boolValue;
        public string stringValue;
        public int intValue;
        public float floatValue;
        public Object objectValue;
        public Transform transformValue;
        public Vector2 vector2Value;
        public Vector3 vector3Value;
        public Color colorValue = Color.black;
        public Gradient gradientValue;
        public AnimationCurve curveValue = AnimationCurve.Linear(0, 0, 1, 1);
        public LayerMask layerMaskValue;
        public string tagValue;
        public Rect rectValue;
        public Bounds boundsValue;
        public long longValue;
        public double doubleValue;
        public Vector2Int vector2IntValue;
        public Vector3Int vector3IntValue;
        public RectInt rectIntValue;
        public Hash128 hash128Value;
        public Vector4 vector4Value;
        public int maskValue;
        public int layerValue;


        public T ConvertValue<T>()
        {
            return type switch
            {
                BlackboardValueType.Bool => AsBool<T>(boolValue),
                BlackboardValueType.String => AsString<T>(stringValue),
                BlackboardValueType.Int => AsInt<T>(intValue),
                BlackboardValueType.Float => AsFloat<T>(floatValue),
                BlackboardValueType.Object => AsObject<T>(objectValue),
                BlackboardValueType.Transform => AsTransform<T>(transformValue),
                BlackboardValueType.Vector2 => AsVector2<T>(vector2Value),
                BlackboardValueType.Vector3 => AsVector3<T>(vector3Value),
                BlackboardValueType.Color => AsColor<T>(colorValue),
                BlackboardValueType.Gradient => AsGradient<T>(gradientValue),
                BlackboardValueType.Curve => AsCurve<T>(curveValue),
                BlackboardValueType.LayerMask => AsLayerMask<T>(layerMaskValue),
                BlackboardValueType.Tag => AsTag<T>(tagValue),
                BlackboardValueType.Rect => AsRect<T>(rectValue),
                BlackboardValueType.Bounds => AsBounds<T>(boundsValue),
                BlackboardValueType.Long => AsLong<T>(longValue),
                BlackboardValueType.Double => AsDouble<T>(doubleValue),
                BlackboardValueType.Vector2Int => AsVector2Int<T>(vector2IntValue),
                BlackboardValueType.Vector3Int => AsVector3Int<T>(vector3IntValue),
                BlackboardValueType.RectInt => AsRectInt<T>(rectIntValue),
                BlackboardValueType.Hash128 => AsHash128<T>(hash128Value),
                BlackboardValueType.Vector4 => AsVector4<T>(vector4Value),
                BlackboardValueType.Mask => AsMask<T>(maskValue),
                BlackboardValueType.Layer => AsLayer<T>(layerValue),
                _ => throw new System.NotSupportedException($"Value type {type} is not supported")
            };
        }

        T AsBool<T>(bool value) => typeof(T) == typeof(bool) && value is T correctType ? correctType : default;
        T AsString<T>(string value) => typeof(T) == typeof(string) && value is T correctType ? correctType : default;
        T AsInt<T>(int value) => typeof(T) == typeof(int) && value is T correctType ? correctType : default;
        T AsFloat<T>(float value) => typeof(T) == typeof(float) && value is T correctType ? correctType : default;
        T AsObject<T>(Object value) => typeof(T) == typeof(Object) && value is T correctType ? correctType : default;
        T AsTransform<T>(Transform value) => typeof(T) == typeof(Transform) && value is T correctType ? correctType : default;
        T AsVector2<T>(Vector2 value) => typeof(T) == typeof(Vector2) && value is T correctType ? correctType : default;
        T AsVector3<T>(Vector3 value) => typeof(T) == typeof(Vector3) && value is T correctType ? correctType : default;
        T AsColor<T>(Color value) => typeof(T) == typeof(Color) && value is T correctType ? correctType : default;
        T AsGradient<T>(Gradient value) => typeof(T) == typeof(Gradient) && value is T correctType ? correctType : default;
        T AsCurve<T>(AnimationCurve value) => typeof(T) == typeof(AnimationCurve) && value is T correctType ? correctType : default;
        T AsLayerMask<T>(LayerMask value) => typeof(T) == typeof(LayerMask) && value is T correctType ? correctType : default;
        T AsTag<T>(string value) => typeof(T) == typeof(string) && value is T correctType ? correctType : default;
        T AsRect<T>(Rect value) => typeof(T) == typeof(Rect) && value is T correctType ? correctType : default;
        T AsBounds<T>(Bounds value) => typeof(T) == typeof(Bounds) && value is T correctType ? correctType : default;
        T AsLong<T>(long value) => typeof(T) == typeof(long) && value is T correctType ? correctType : default;
        T AsDouble<T>(double value) => typeof(T) == typeof(double) && value is T correctType ? correctType : default;
        T AsVector2Int<T>(Vector2Int value) => typeof(T) == typeof(Vector2Int) && value is T correctType ? correctType : default;
        T AsVector3Int<T>(Vector3Int value) => typeof(T) == typeof(Vector3Int) && value is T correctType ? correctType : default;
        T AsRectInt<T>(RectInt value) => typeof(T) == typeof(RectInt) && value is T correctType ? correctType : default;
        T AsHash128<T>(Hash128 value) => typeof(T) == typeof(Hash128) && value is T correctType ? correctType : default;
        T AsVector4<T>(Vector4 value) => typeof(T) == typeof(Vector4) && value is T correctType ? correctType : default;
        T AsMask<T>(int value) => typeof(T) == typeof(int) && value is T correctType ? correctType : default;
        T AsLayer<T>(int value) => typeof(T) == typeof(int) && value is T correctType ? correctType : default;
    }
}