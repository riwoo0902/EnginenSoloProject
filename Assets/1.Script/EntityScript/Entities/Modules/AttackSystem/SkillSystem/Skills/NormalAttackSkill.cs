using _1.Script.EntityScript.Entities.Modules.StatSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills
{
    public class NormalAttackSkill : AbstractSkill
    {
        private StatSO _attackSpeedStat;
        private float _lastAttackTime = 0;
        public override void Initialize(Entity owner)
        {
            base.Initialize(owner);
            
            IStatModule statModule = entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null, "StatModule is not found");
            
            Debug.Assert(statModule.TryGetStat(Stats.AttackSpeed,out _attackSpeedStat),"AttackSpeed stat is not found");
            
        }
        
        public override bool CanUseSkill()
        {
            if (Time.time - _lastAttackTime >= _attackSpeedStat.Value)
            {
                return true;
            }
            
            return false;
        }

        public override void UseSkill()
        {
            _lastAttackTime = Time.time;
        }
        
        
        
    }
}