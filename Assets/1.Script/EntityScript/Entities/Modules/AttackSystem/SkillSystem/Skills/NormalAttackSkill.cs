using _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills.NormalAttackSkillScript;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills
{
    public class NormalAttackSkill : AbstractSkill
    {
        private StatSO _attackSpeedStat;
        private StatSO _damageStat;
        private float _lastAttackTime = 0;
        private Transform _target;
        [SerializeField] private GameObject prefab;
        public override void Initialize(Entity owner)
        {
            base.Initialize(owner);
            
            Debug.Assert(statModule.TryGetStat(Stats.AttackSpeed,out _attackSpeedStat),"AttackSpeed stat is not found");
            Debug.Assert(statModule.TryGetStat(Stats.AttackDamage,out _damageStat),"AttackDamage stat is not found");
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

            GameObject bullet = Instantiate(prefab);
            bullet.transform.position = entity.transform.position;
            if (bullet.TryGetComponent(out TargetBullet targetBullet))
            {
                targetBullet.SetData(entity.myTeam,_target,_damageStat.Value,10);
            }
            
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
        
    }
}