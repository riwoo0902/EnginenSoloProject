using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using _1.Script.EntityScript.Entities.UnitScript.Units;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM
{
    public abstract class AbstractState
    {
        protected MoveUnit moveUnit;
        protected IMoveModule moveModule;
        
        public AbstractState(MoveUnit owner)
        {
            moveUnit = owner;
            Debug.Assert(owner.TryGetModule(out moveModule),"moveModule is not found");
            
        }
        
        public abstract void Enter(Vector3 point);
        
        public abstract void Update();
        
        public abstract void FixedUpdate();

        public abstract void Exit();

    }
}