using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        protected Entity entity;
        
        public virtual void Initialize(Entity owner)
        {
            entity = owner;
        }


        public virtual bool CanUseSkill()
        {
            return true;
        }
        public abstract void UseSkill();

    }
}