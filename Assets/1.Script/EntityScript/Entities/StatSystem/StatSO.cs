using System;
using _2.So._1.Scripts.DataBase;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.StatSystem
{
    [CreateAssetMenu(fileName = "New Stat", menuName = "Stat/Stat data")]
    public class StatSO : IndexedAsset
    {
        public delegate void ChangeStatValue(StatSO stat, float value,float oldValue);
        public event ChangeStatValue OnValueChanged;
        
        [field : SerializeField] public Sprite StatIcon { get; private set; }
        [field : SerializeField] public string StatName { get; private set; }
        [field : SerializeField] public string DisplayName { get; private set; }
        
        [SerializeField] private float minValue, maxValue;

        private float _value;
        public float Value
        {
            get => _value;
            set
            {
                float previous = Value;
                float nowValue = Mathf.Clamp(value, minValue, maxValue);
                TryInvokeValueChangeEvent(nowValue, previous);
            }
        }

        private void OnEnable()
        {
            
        }

        private void TryInvokeValueChangeEvent(float value, float previous)
        {
            if (Mathf.Approximately(value, previous) == false)
            {
                OnValueChanged?.Invoke(this, value, previous);
            }
            
        }

        public StatSO Clone()
        {
            return Instantiate(this); //자기자신을 복제해서 리턴해준다.
        }
        
    }
}