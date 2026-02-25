using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntitiesManager : MonoSingleton<EntitiesManager>
    {
        [SerializeField] private EventChannel entityChannel;
        
        public List<Entity> entities = new(300);

        protected override void Awake()
        {
            base.Awake();
            entityChannel.AddListener<EntitySpawnEvent>(AddEntityList);  
            entityChannel.AddListener<EntityDestroyEvent>(RemoveEntityList);  
        }

        private void AddEntityList(EntitySpawnEvent evt)
        {
            entities.Add(evt.entity);
        }

        private void RemoveEntityList(EntityDestroyEvent evt)
        {
            entities.Remove(evt.entity);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            entityChannel.RemoveListener<EntitySpawnEvent>(AddEntityList);  
            entityChannel.AddListener<EntityDestroyEvent>(RemoveEntityList);  
        }
    }
}