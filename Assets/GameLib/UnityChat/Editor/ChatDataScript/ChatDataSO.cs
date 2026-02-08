using _2.So._1.Scripts.DataBase;
using UnityEngine;

namespace GameLib.UnityChat.Editor.ChatDataScript
{
    [CreateAssetMenu(fileName = "ChatData", menuName = "UnityChat/ChatData", order = 0)]
    public class ChatDataSO : IndexedAsset
    {
        public string chatName;
        public ChatData[] chatData;
        
        
    }

    public struct ChatData
    {
        public string userName;
        public string message;
    }
}