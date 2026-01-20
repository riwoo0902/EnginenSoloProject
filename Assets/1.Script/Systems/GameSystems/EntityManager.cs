using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntityManager : MonoSingleton<EntityManager>
    {
        [SerializeField] private List<Entity> selectedEntities = new();
        
        protected override void Awake()
        {
            base.Awake();
            
        }



        public void AddEntity(Entity entity)
        {
            selectedEntities.Add(entity);
            EventBus<ChangeSelectedEntityData>.Raise(new ChangeSelectedEntityData(selectedEntities));
        }

        public void RemoveEntity(Entity entity)
        {
            selectedEntities.Remove(entity);
        }
        
        
        public int CheckEntity(Func<Entity,bool> action,out List<Entity> result)
        {
            int count = 0;
            result = new List<Entity>(selectedEntities.Count);
            
            foreach (Entity entity in selectedEntities)
            {
                if (action(entity))
                {
                    count++;
                    result.Add(entity);
                }
            }
            
            return count;
        }
        
        
        
    }
}