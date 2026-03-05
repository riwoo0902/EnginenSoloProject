using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster
{
    public abstract class AbstractDamageCaster : MonoBehaviour
    {
        protected AttackData currentAttackData;
        protected Team myTeam;
        public void SetAttackData(Team team,AttackData data)
        {
            myTeam = team;
            currentAttackData = data;
        }

        protected abstract bool CanAttack(Entity target);
        protected abstract void Attack(Entity target);
        
    }

    public struct AttackData
    {
        public float damage;
        public Team attackerTeam;
    }
}