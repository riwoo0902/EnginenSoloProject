using System;
using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem
{
    public class SkillModule : MonoBehaviour,IModule
    {
        private Entity _entity;
        
        private Dictionary<Type,AbstractSkill> _skills = new();
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            Debug.Assert(_entity != null,"Entity is not found");
            
            _skills = GetComponentsInChildren<AbstractSkill>().ToDictionary(skill => skill.GetType());
            
        }

        public bool TryGetSkill(Type skillType,out AbstractSkill skillInstance)
        {
            return _skills.TryGetValue(skillType, out skillInstance);
        }
        
        
    }
}