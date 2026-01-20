using _1.Script.EntityScript.Module;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;
using UnityEngine;

namespace _1.Script.EntityScript.Entities
{
    public abstract class Entity : ModuleOwner
    {
        public Team myTeam;
        
        protected override void Awake()
        {
            base.Awake();
            
            EventBus<EntitySpawn>.Raise(new EntitySpawn(this));
            
        }

        public bool IsTeam(Team team) => myTeam == team;
        
        
    }
}