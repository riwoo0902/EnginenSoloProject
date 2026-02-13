using System.Collections.Generic;
using System.Linq;
using _2.So._1.Scripts.DataBase;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.StatSystem
{
    [CreateAssetMenu(fileName = "New Stat Table", menuName = "Stat/Stat Table")]
    public class StatSettingTable : DataTable<StatSO>
    {
        private static Dictionary<string,int> _statIndexData;
        private void OnEnable()
        {
            _statIndexData = Datas.ToDictionary(data => data.StatName, data => data.Index);
        }

        public static int GetStatIndex(string statName)
        {
            if (_statIndexData.ContainsKey(statName))
            {
                return _statIndexData[statName];
            }
            
            Debug.LogError("Stat Index Not Found: " + statName);
            return -1;
        }
        

        private void OnValidate()
        {
            if (Datas != null)
            {
                for (int i = 0; i < Datas.Length; i++)
                {
                    Datas[i].Index = i;
                }
            }
            
            
        }
    }
}