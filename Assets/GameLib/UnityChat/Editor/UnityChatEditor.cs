using GameLib.UnityChat.Editor.ChatDataScript;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameLib.UnityChat.Editor
{
    public class UnityChatEditor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset editorView = default;
        [SerializeField] private ChatDataTable chatData = default;
        [SerializeField] private VisualTreeAsset chatDataAsset = default;
        
        [MenuItem("Tools/UnityChat")]
        private static void OpenWindow()
        {
            UnityChatEditor window = GetWindow<UnityChatEditor>();
            window.titleContent = new GUIContent("UnityChat");
            //window.Show();
        }
        
        private void CreateGUI()
        {
            
        }
    }
}