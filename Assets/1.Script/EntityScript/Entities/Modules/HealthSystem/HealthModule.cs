using System;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.HealthSystem
{
    public class HealthModule : MonoBehaviour , IModule
    {
        public delegate void HealthChange(float before, float current, float max);
        public event HealthChange OnHealthChange;
        
        public event Action OnDead;
        
        private Entity _entity;
        [SerializeField] private float hp;
        private StatSO _maxHpStat;
        public float MaxHp => _maxHpStat.Value;
        public bool IsDead { get; private set; }  = false;

        public float Hp
        {
            get => hp;
            set
            {
                float before = hp;
                hp = Mathf.Clamp(value, 0, _maxHpStat.Value);
                OnHealthChange?.Invoke(before, value, _maxHpStat.Value);
            }
        }
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            OnHealthChange += DeadChack;
        }

        public void AfterInitialize()
        {
            IStatModule statModule = _entity.GetModule<IStatModule>();
            
            Debug.Assert(statModule != null,"statModule is not found");
            
            Debug.Assert(statModule.TryGetStat(Stats.MaxHp, out _maxHpStat),"MaxHP Stat is not found");
            
            Hp = _maxHpStat.Value;
            _maxHpStat.OnValueChanged += MaxHpStatOnOnValueChanged;
            
            
        }

        private void MaxHpStatOnOnValueChanged(float value, float oldValue)
        {
            Hp += 0;
        }

        private void OnDestroy()
        {
            OnHealthChange -= DeadChack;
            _maxHpStat.OnValueChanged -= MaxHpStatOnOnValueChanged;
        }


        private void DeadChack(float before, float current, float max)
        {
            if (current <= 0 && IsDead == false)
            {
                IsDead = true;
                OnDead?.Invoke();
                
            }
        }

        [ContextMenu("Damage 10")]
        private void Damage10()
        {
            Hp -= 10;
        }
        
        
    }
}