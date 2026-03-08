using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM
{
    public abstract class AbstractState
    {
        protected Entity entity;
        protected IMoveModule moveModule;
        
        public AbstractState(Entity owner)
        {
            entity = owner;
            Debug.Assert(owner.TryGetModule(out moveModule),"moveModule is not found");
            
        }
        
        public abstract void Enter(Vector3 point);
        
        public abstract void Update();

        public abstract void Exit();

    }
}