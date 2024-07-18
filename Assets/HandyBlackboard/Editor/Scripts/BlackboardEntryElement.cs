using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace IndieGabo.HandyBlackboard.Editor
{
    [CustomPropertyDrawer(typeof(BlackboardEntry<>))]
    public class BlackboardEntryPropertyDrawer : PropertyDrawer
    {
        private const string TemplateName = "BlackboardEntryElement";

        private TemplateContainer _containerMain;

        private VisualElement _containerValue;
        private TextField _fieldKey;
        private PropertyField _fieldValue;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            SerializedProperty keyProperty = property.FindPropertyRelative("Key");
            SerializedProperty keyNameProperty = keyProperty.FindPropertyRelative("_name");

            _containerMain = Resources.Load<VisualTreeAsset>($"UXML/{TemplateName}").Instantiate();

            _fieldKey = _containerMain.Q<TextField>("field-key");
            _fieldKey.SetValueWithoutNotify(keyNameProperty.stringValue);

            _fieldValue = _containerMain.Q<PropertyField>("field-value");
            _fieldValue.BindProperty(property.FindPropertyRelative("Value"));

            return _containerMain;
        }
    }
}