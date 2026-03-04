using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.ModuleSystem;
using _1.Script.Systems.GameSystems;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem
{
    public interface IAttackSenserModule
    {
        bool TryGetTarget(out Entity target);
    }

    public class AttackSenserModule : MonoBehaviour,IModule, IAttackSenserModule
    {
        private StatSO _attackRangeStat;
        
        private Entity _entity;
        
        private List<Entity> _entities;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            Debug.Assert(_entity != null,"Entity is not found");
            IStatModule statModule = _entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null,"StatModule is not found");
            
            Debug.Assert(statModule.TryGetStat(Stats.AttackRange,out _attackRangeStat),"AttackRange Stat is not found");

            _entities = EntitiesManager.Instance.entities;
        }

        public bool TryGetTarget(out Entity target)
        {
            target = null;
            
            float minDistance = float.MaxValue;
            
            foreach (Entity entity in _entities)
            {
                if(!TeamCheck.IsEnemy(_entity.myTeam, entity.myTeam)) continue;
                Vector3 vec = entity.transform.position - _entity.transform.position;
                float distance = vec.magnitude;
                if (distance < _attackRangeStat.Value && distance < minDistance)
                {
                    if (!Physics.Raycast(_entity.transform.position,vec,LayerMask.NameToLayer("Map")))
                    {
                        target = entity;
                        minDistance = distance;
                    }
                    
                }
            }
            
            return target != null;
        }
        
        
        
        
    }
}