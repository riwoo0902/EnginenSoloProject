using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.Systems;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.UnitScript
{
    public class Unit : Entity
    {
        protected IStatModule statModule;
        protected HealthModule healthModule;
        
        protected override void Awake()
        {
            base.Awake();
            statModule = GetModule<IStatModule>();
            healthModule = GetModule<HealthModule>();
            healthModule.OnDead += AddScore;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            healthModule.OnDead -= AddScore;
        }

        private void AddScore()
        {
            entityChannel.RaiseEvent(EntityEvents.ScoreAdd.Init((int)healthModule.MaxHp / 10));
        }
    }
}