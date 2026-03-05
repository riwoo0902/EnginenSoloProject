using System.Collections.Generic;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster.DamageCasters
{
    [RequireComponent(typeof(Collider))]
    public class OneDamageCaster : AbstractDamageCaster
    {
        private readonly List<Entity> _entities = new();
        
        protected override bool CanAttack(Entity target)
        {
            if(TeamCheck.IsTeam(myTeam,target.myTeam)) return false;
            if(_entities.Contains(target)) return false;
            
            return true;
        }

        protected override void Attack(Entity target)
        {
            _entities.Add(target);

            if (target.TryGetModule(out HealthModule healthModule))
            {
                healthModule.Hp -= currentAttackData.damage;
            }
        }

        private void OnTriggerEnter(Collider other)
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