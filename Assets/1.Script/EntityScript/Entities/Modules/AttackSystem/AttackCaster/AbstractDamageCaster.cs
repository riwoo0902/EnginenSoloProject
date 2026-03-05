using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster
{
    public abstract class AbstractDamageCaster : MonoBehaviour
    {
        protected AttackData currentAttackData;

        public void SetAttackData(AttackData data)
        {
            currentAttackData = data;
        }

        protected abstract bool CanAttack(Entity target);
        protected abstract void Attack(Entity healthModule);
        
    }

    public struct AttackData
    {
        public float damage;
        public Team attackerTeam;
    }
}