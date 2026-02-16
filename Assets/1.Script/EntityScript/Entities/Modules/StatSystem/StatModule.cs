using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.StatSystem
{
    public interface IStatModule
    {
        bool TryGetStat(Stats statName, out StatSO value);
        void SubscribeStat(Stats statName, StatSO.ChangeStatValue handler);
        void UnSubscribeStat(Stats statName, StatSO.ChangeStatValue handler);
    }

    public class StatModule : MonoBehaviour , IModule, IStatModule
    {
        private ModuleOwner _entity;
        
        [SerializeField] private StatOverride[] statOverrides;
        private Dictionary<int, StatSO> _statDict;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner;
            _statDict = statOverrides.ToDictionary(stat => stat.stat.Index, stat => stat.CreateStat());
            
            
        }

        public bool TryGetStat(Stats statName, out StatSO value) => _statDict.TryGetValue((int)statName, out value);
        
        
        public void SubscribeStat(Stats statName, StatSO.ChangeStatValue handler)
        {
            if (_statDict.TryGetValue((int)statName, out StatSO stat))
            {
                stat.OnValueChanged += handler;
            }
        }
        
        public void UnSubscribeStat(Stats statName, StatSO.ChangeStatValue handler)
        {
            if (_statDict.TryGetValue((int)statName, out StatSO stat))
            {
                stat.OnValueChanged -= handler;
            }
        }
        
    }
}