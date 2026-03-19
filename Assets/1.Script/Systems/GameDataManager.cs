using System;
using _1.Script.Systems.GameSystems.SaveSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems
{
    public class GameDataManager : MonoBehaviour,ISaveAble
    {
        [SerializeField] private EventChannel entityChannel;
        [field:SerializeField] public SaveIdData SaveId { get; private set; }

        public static int GameData = -1;
        // 0 : lose , 1 : win

        private void Awake()
        {
            entityChannel.AddListener<GameEndEvent>(GameEnd);
        }

        private void GameEnd(GameEndEvent obj)
        {
            GameData = 0;
        }

        public string GetSaveData()
        {
            return GameData.ToString();
        }

        public void RestoreData(string data) { }
    }
}