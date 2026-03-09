using _1.Script.EntityScript.Entities.Modules.StatSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        protected Entity entity;
        protected IStatModule statModule;
        
        public virtual void Initialize(Entity owner)
        {
            entity = owner;
            
            statModule = entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null, "StatModule is not found");
        }


        public virtual bool CanUseSkill()
        {
            return true;
        }
        public abstract void UseSkill();

    }
}