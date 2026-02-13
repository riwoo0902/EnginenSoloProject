using System;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.StatSystem
{
    [Serializable]
    public class StatOverride
    {
        [SerializeField] public StatSO stat;
        [SerializeField] public int startValue;
        
        public StatOverride(StatSO stat) => this.stat = stat; //생성자

        public StatSO CreateStat()
        {
            StatSO newStat = stat.Clone();

            Debug.Assert(newStat != null, $"StatSO Clone Error : check {stat.StatName}");
            
            newStat.Value = startValue;
            
            return newStat;
        }
        
    }
}