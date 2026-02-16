using System.IO;
using System.Linq;
using _1.Script.Systems;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace _1.Script.EntityScript.Entities.StatSystem.Editor
{
    [CustomEditor(typeof(StatSettingTable))]
    public class StatSettingTableEditor : UnityEditor.Editor
    {
        [SerializeField] private VisualTreeAsset editorView = default;
        
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            editorView.CloneTree(root);

            root.Q<Button>("GenerateButton").clicked += HandleGenerateEnumClick;
            
            return root;
        }

        private void HandleGenerateEnumClick()
        {
            StatSettingTable listData = target as StatSettingTable;
            
            Debug.Assert(listData != null, "Target data is null check editor");
            
            int index = 0;
            string enumString = string.Join(",", listData.Datas.Select(so =>
            {
                so.Index = index;
                EditorUtility.SetDirty(so);
                return $"{so.StatName} = {index++}";
            }));
            
            string code = string.Format(CodeFormat.EnumFormat, "_1.Script.EntityScript.Entities.StatSystem", "Stats", enumString);

            string scriptPath = AssetDatabase.GetAssetPath( MonoScript.FromScriptableObject(this));
            string directoryName = Path.GetDirectoryName(scriptPath); //이 코드가 있는 디렉토리를 가져와.
            Debug.Assert(directoryName != null, "Parent directory is null");
            
            DirectoryInfo parentDirectory = Directory.GetParent(directoryName); //이 코드의 디렉토리의 부모 디렉토리 가져와
            Debug.Assert(parentDirectory != null, "Parent directory is null");
            
            string path = parentDirectory.FullName;
            File.WriteAllText($"{path}/Stats.cs", code);
            
            AssetDatabase.SaveAssets(); //Ctrl+s키랑 같은 기능
            AssetDatabase.Refresh(); //갱신 -> 이걸 해야 새롭게 컴파일을 한다.
        }
    }
}