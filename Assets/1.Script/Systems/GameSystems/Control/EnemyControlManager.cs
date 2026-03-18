using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.ControlListenerSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems.Control
{
    public class EnemyControlManager : MonoSingleton<EnemyControlManager>
    {
        [SerializeField] private EventChannel entityChannel;
        
        private List<IControlListenerModule> _enemys = new(200);

        protected override void Awake()
        {
            base.Awake();
            entityChannel.AddListener<EntitySpawnEvent>(AddEntityList);  
            entityChannel.AddListener<EntityDestroyEvent>(RemoveEntityList);  
        }

        private void AddEntityList(EntitySpawnEvent obj)
        {
            if (TeamCheck.IsTeam(obj.entity.myTeam, Team.Red))
            {
                if (obj.entity.TryGetModule(out IControlListenerModule controlListenerModule))
                {
                    _enemys.Add(controlListenerModule);
                }
            }
        }

        private void RemoveEntityList(EntityDestroyEvent obj)
        {
            if (TeamCheck.IsTeam(obj.entity.myTeam, Team.Red))
            {
                if (obj.entity.TryGetModule(out IControlListenerModule controlListenerModule))
                {
                    _enemys.Remove(controlListenerModule);
                }
            }
        }

        [ContextMenu("Lenght")]
        private void Lenght()
        {
            Debug.Log(_enemys.Count);
        }
        
        
        
    }
}