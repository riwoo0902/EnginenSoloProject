using System;
using _1.Script.EntityScript.Module;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.EntityScript.Entities
{
    public abstract class Entity : ModuleOwner
    {
        [SerializeField] public int Id { get; private set; }
        [SerializeField] private EventChannel entityChannel;
        public event Action<bool> Selection;
        
        protected override void Awake()
        {
            base.Awake();
            
        }

        protected virtual void Start()
        {
            entityChannel.RaiseEvent(EntityEvents.EntitySpawn.Init(this));
        }
        
        protected virtual void OnDestroy()
        {
            entityChannel.RaiseEvent(EntityEvents.EntityDestroy.Init(this));
        }

        public void SelectEntity(bool select)
        {
            Selection?.Invoke(select);
        }
        

    }
}