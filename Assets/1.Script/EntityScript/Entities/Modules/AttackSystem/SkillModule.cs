using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem
{
    public class SkillModule : MonoBehaviour,IModule
    {
        private StatSO _attackRangeStat;
        
        private Entity _entity;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            Debug.Assert(_entity != null,"Entity is not found");
            
            IStatModule statModule = _entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null,"StatModule is not found");
            
            
            Debug.Assert(_entity != null,"Entity is not found");
        }
        
        
    }
}