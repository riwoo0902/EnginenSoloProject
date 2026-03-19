using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.FSM;
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
            entityChannel.AddListener<PlayerMoveEvent>(EnemyControl);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            entityChannel.RemoveListener<EntitySpawnEvent>(AddEntityList);
            entityChannel.RemoveListener<EntityDestroyEvent>(RemoveEntityList);
            entityChannel.RemoveListener<PlayerMoveEvent>(EnemyControl);
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
        
        private void EnemyControl(PlayerMoveEvent evt)
        {
            foreach (IControlListenerModule enemy in _enemys)
            {
                enemy.Control(evt.playerPos, StateType.AttackMove);
            }
        }

        [ContextMenu("Lenght")]
        private void Lenght()
        {
            Debug.Log(_enemys.Count);
        }
        
        
        
    }
}