using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.MoveSystem
{
    public class MoveModule : MonoBehaviour, IModule
    {
        private Entity _entity;
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            
            
        }
        
        
    }
}