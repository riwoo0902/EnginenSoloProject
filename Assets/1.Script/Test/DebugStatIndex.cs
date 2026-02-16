using _1.Script.EntityScript.Entities.StatSystem;
using UnityEngine;

namespace _1.Script.Test
{
    public class DebugStatIndex : MonoBehaviour
    {
        [SerializeField] private Stats _statName;
        
        [ContextMenu("DebugStatIndex")]
        private void StatIndex()
        {
            Debug.Log((int)_statName);
        }
    }
}