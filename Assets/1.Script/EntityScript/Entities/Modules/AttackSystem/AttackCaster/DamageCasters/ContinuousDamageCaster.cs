using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster.DamageCasters
{
    [RequireComponent(typeof(Collider))]
    public class ContinuousDamageCaster : AbstractDamageCaster
    {
        [SerializeField] private float attackDelay = 0.2f;
        
        private readonly Dictionary<Entity,float> _attackDelays = new();
        protected override bool CanAttack(Entity target)
        {
            if(TeamCheck.IsTeam(myTeam,target.myTeam)) return false;
            
            if (_attackDelays.TryGetValue(target, out float delay))
            {
                return Time.time - delay >= attackDelay;
            }
            return true;
        }

        protected override void Attack(Entity target)
        {
            _attackDelays[target] = Time.time;
            
            if (target.TryGetModule(out HealthModule healthModule))
            {
                healthModule.Hp -= currentAttackData.damage;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Entity target))
            {
                if (CanAttack(target))
                {
                    Attack(target);
                }
            }
        }
    }
}