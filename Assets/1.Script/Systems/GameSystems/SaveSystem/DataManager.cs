using System;
using System.Collections.Generic;
using System.Linq;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems.SaveSystem
{
    public class DataManager : MonoBehaviour
    {
        [Serializable]
        public struct SaveData
        {
            public int Id;
            public string Data;
        }
        
        [Serializable]
        public struct DataCollection
        {
            public List<SaveData> Collection;
        }

        [SerializeField] private string prefKey = "saveData";

        //이번씬에서 사용하지 않는 세이브된 데이터를 가지고 있다.
        private List<SaveData> _unUsedData = new List<SaveData>();
        [field: SerializeField] public EventChannel SystemChannel { get; private set; }

        private void Awake()
        {
            SystemChannel.AddListener<SavePrefEvent>(HandleSavePrefEvent);
            SystemChannel.AddListener<LoadPrefEvent>(HandleLoadPrefEvent);
        }

        private void OnDestroy()
        {
            SystemChannel.RemoveListener<SavePrefEvent>(HandleSavePrefEvent);
            SystemChannel.RemoveListener<LoadPrefEvent>(HandleLoadPrefEvent);
        }

        #region 데이터 세이브 로직

        private void HandleSavePrefEvent(SavePrefEvent evt)
        {
            string saveData = GetSceneSaveData();
            PlayerPrefs.SetString(prefKey, saveData);
            Debug.Log($"Save Data : {saveData}");
        }

        private string GetSceneSaveData()
        {
            IEnumerable<ISaveAble> saveableObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveAble>();
            
            List<SaveData> toSaveData = new List<SaveData>();
            foreach (ISaveAble saveable in saveableObjects)
            {
                toSaveData.Add(new SaveData{Id = saveable.SaveId.Id, Data = saveable.GetSaveData()});
            }
            toSaveData.AddRange(_unUsedData); //이번 씬에서 사용하지 않았던 데이터도 같이 저장한다.
            DataCollection dataCollection = new DataCollection{Collection = toSaveData};
            
            return JsonUtility.ToJson(dataCollection);
        }
        
        #endregion

        #region 데이터 로드 관련 로직
        
        private void HandleLoadPrefEvent(LoadPrefEvent evt)
        {
            string loadJson = PlayerPrefs.GetString(prefKey, string.Empty);
            RestoreData(loadJson);
        }

        private void RestoreData(string json)
        {
            IEnumerable<ISaveAble> saveables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveAble>();
            DataCollection parsedData = string.IsNullOrEmpty(json)
                ? new DataCollection()
                : JsonUtility.FromJson<DataCollection>(json);
            
            _unUsedData.Clear();

            if (parsedData.Collection != null)
            {
                foreach (SaveData saveData in parsedData.Collection)
                {
                    ISaveAble saveAble = saveables.FirstOrDefault(s => s.SaveId.Id == saveData.Id);
                    if(saveAble != null)
                        saveAble.RestoreData(saveData.Data);
                    else
                        _unUsedData.Add(saveData);
                }
            }
            
        }

        #endregion

        [ContextMenu("Clear Pref Data")]
        public void ClearPrefData()
        {
            PlayerPrefs.DeleteKey(prefKey);
        }
    }
}