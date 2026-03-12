using System;
using GameLib.ObjectPool.Runtime;
using TMPro;
using UnityEngine;

namespace _1.Script.UI
{
    public class ScoreUI : MonoBehaviour,IPoolable
    {
        [field:SerializeField] public PoolItemSO PoolItem { get; set; }
        private TextMeshProUGUI _textMeshProUGUI;
        public GameObject GameObject => gameObject;

        private void Awake()
        {
            
        }

        public void ResetItem()
        {
            
        }
        
        
        
        
        
    }
}