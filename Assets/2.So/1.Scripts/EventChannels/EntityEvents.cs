using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.FSM;
using UnityEngine;

namespace _2.So._1.Scripts.EventChannels
{
    public static class EntityEvents
    {
        public static readonly EntitySpawnEvent EntitySpawn = new EntitySpawnEvent();
        public static readonly EntityDestroyEvent EntityDestroy = new EntityDestroyEvent();
    }

    public class EntitySpawnEvent : GameEvent
    {
        public Entity entity;
        
        public EntitySpawnEvent Init(Entity data)
        {
            entity = data;
            return this;
        }
    }
    public class EntityDestroyEvent : GameEvent
    {
        public Entity entity;
        
        public EntityDestroyEvent Init(Entity data)
        {
            entity = data;
            return this;
        }
    }

    
}