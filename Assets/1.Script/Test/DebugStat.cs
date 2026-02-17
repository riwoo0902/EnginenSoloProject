using _1.Script.EntityScript.Entities.Modules.StatSystem;
using UnityEngine;

namespace _1.Script.Test
{
    public class DebugStat : MonoBehaviour
    {
        [SerializeField] private Stats statName;
        [SerializeField] private StatModule statModule;
        [SerializeField] private float addValue;
        [ContextMenu("DebugStatIndex")]
        private void StatIndex()
        {
            Debug.Log((int)statName);
        }
        
        [ContextMenu("DebugStatValue")]
        private void StatValue()
        {
            statModule.TryGetStat(statName, out StatSO statValue);
            Debug.Log(statValue.Value);
        }
        
        [ContextMenu("DebugAddStatValue")]
        private void AddStatValue()
        {
            statModule.TryGetStat(statName, out StatSO statValue);
            statValue.Value += addValue;
        }
    }
}