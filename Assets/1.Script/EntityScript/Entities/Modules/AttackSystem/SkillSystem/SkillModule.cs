using System;
using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem
{
    public interface ISkillModule
    {
        bool TryGetSkill<T>(out T skillInstance) where T : AbstractSkill;
    }

    public class SkillModule : MonoBehaviour,IModule, ISkillModule
    {
        private Entity _entity;
        
        private Dictionary<Type,AbstractSkill> _skills = new();
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            Debug.Assert(_entity != null,"Entity is not found");
            
            _skills = GetComponentsInChildren<AbstractSkill>().ToDictionary(skill => skill.GetType());
            foreach (AbstractSkill value in _skills.Values)
            {
                value.Initialize(_entity);
            }
        }

        public bool TryGetSkill<T>(out T skillInstance) where T : AbstractSkill
        {
            if(_skills.TryGetValue(typeof(T), out AbstractSkill skill))
            {
                skillInstance = skill as T;
                return true;
            }

            skillInstance = null;
            return false;
        }
        
        
    }
}