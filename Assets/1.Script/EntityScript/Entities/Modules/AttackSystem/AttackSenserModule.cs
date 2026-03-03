using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.ModuleSystem;
using _1.Script.Systems.GameSystems;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem
{
    public class AttackSenserModule : MonoBehaviour,IModule
    {
        private StatSO _attackRangeStat;
        
        private Entity _entity;
        
        private List<Entity> _entities;
        
        private Entity _entityTarget;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            Debug.Assert(_entity != null,"Entity is not found");
            IStatModule statModule = _entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null,"StatModule is not found");
            
            Debug.Assert(statModule.TryGetStat(Stats.AttackRange,out _attackRangeStat),"AttackRange Stat is not found");

            _entities = EntitiesManager.Instance.entities;
        }

        private void FixedUpdate()
        {
            TryGetTarget(out _entityTarget);
        }


        public bool TryGetTarget(out Entity target)
        {
            target = null;
            
            float minDistance = float.MaxValue;
            
            foreach (Entity entity in _entities)
            {
                float distance = (entity.transform.position - _entity.transform.position).sqrMagnitude;
                if (distance < _attackRangeStat.Value && distance < minDistance)
                {
                    _entityTarget = entity;
                    minDistance = distance;
                }
            }
            
            return target != null;
        }
        
        
        
        
    }
}