using System.Collections.Generic;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster
{
    public abstract class AbstractAttackCaster : MonoBehaviour
    {
        private AttackData _currentAttackData;

        public void SetAttackData(AttackData data)
        {
            _currentAttackData = data;
        }
        
        
    }

    public struct AttackData
    {
        public float damage;
        public Team attackerTeam;
    }
}