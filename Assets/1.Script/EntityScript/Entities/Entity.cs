using System;
using _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using _1.Script.EntityScript.ModuleSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using GameLib.ObjectPool.Runtime;
using UnityEngine;

namespace _1.Script.EntityScript.Entities
{
    public class Entity : ModuleOwner
    {
        [SerializeField] private EventChannel entityChannel;
        
        public event Action<bool> Selection;

        public Team myTeam;
        private Collider _collider;
        private HealthModule _healthModule;
        
        protected override void Awake()
        {
            base.Awake();

            if (TryGetComponent(out _collider) && TryGetModule(out _healthModule))
            {
                ColliderManager.Push(_collider, _healthModule);
            }
        }

        protected virtual void Start()
        {
            entityChannel.RaiseEvent(EntityEvents.EntitySpawn.Init(this));
        }
        
        protected virtual void OnDestroy()
        {
            entityChannel.RaiseEvent(EntityEvents.EntityDestroy.Init(this));

            ColliderManager.Remove<HealthModule>(_collider);
        }

        public void SelectEntity(bool select)
        {
            Selection?.Invoke(select);
        }
        
    }
}