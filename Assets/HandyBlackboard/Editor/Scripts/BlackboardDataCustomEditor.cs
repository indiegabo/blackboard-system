using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IndieGabo.HandyBlackboard.Editor
{
    [CustomEditor(typeof(BlackboardData))]
    public class BlackboardDataCustomEditor : UnityEditor.Editor
    {
        private const string TemplateName = "BlackboardDataCustomEditor";

        private TemplateContainer _containerMain;
        private ListView _listEntries;
        private BlackboardData _data;

        public override VisualElement CreateInspectorGUI()
        {
            _data = target as BlackboardData;

            _containerMain = Resources.Load<VisualTreeAsset>($"UXML/{TemplateName}").Instantiate();

            _listEntries = _containerMain.Q<ListView>("list-entries");

            _listEntries.makeItem = () => new BlackboardDataEntryElement();
            _listEntries.bindItem = (e, i) =>
            {
                BlackboardDataEntryElement entryElement = e as BlackboardDataEntryElement;
                entryElement.SetEntry(_data.Entries[i]);
            };

            _listEntries.itemsSource = _data.Entries;

            _listEntries.Q<Button>("unity-list-view__add-button").clickable = new Clickable(() =>
            {
                _data.Entries.Add(new BlackBoardDataEntry());
                _listEntries.RefreshItems();
                EditorUtility.SetDirty(target);
            });

            return _containerMain;
        }
    }
}