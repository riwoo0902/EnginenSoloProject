using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.Module;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.StatSystem
{
    public class StatModule : MonoBehaviour , IModule
    {
        private ModuleOwner _entity;
        
        [SerializeField] private StatOverride[] statOverrides;
        private Dictionary<int, StatSO> _statDict;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner;
            _statDict = statOverrides.ToDictionary(stat => stat.stat.Index, stat => stat.CreateStat());
            
            
        }
        
        
        public void SubscribeStat(string statName, StatSO.ChangeStatValue handler)
        {
            if (_statDict.TryGetValue(StatSettingTable.GetStatIndex(statName), out StatSO stat))
            {
                stat.OnValueChanged += handler;
            }
        }
        
        public void UnSubscribeStat(string statName, StatSO.ChangeStatValue handler)
        {
            if (_statDict.TryGetValue(StatSettingTable.GetStatIndex(statName), out StatSO stat))
            {
                stat.OnValueChanged -= handler;
            }
        }
        
    }
}