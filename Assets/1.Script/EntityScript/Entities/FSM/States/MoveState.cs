using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using _1.Script.EntityScript.Entities.UnitScript.Units;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM.States
{
    public class MoveState : AbstractState
    {
        private IMoveModule _moveModule;
        public MoveState(MoveUnit owner) : base(owner)
        {
            _moveModule = owner.GetModule<IMoveModule>();
        }
        
        public override void Enter(Vector3 point)
        {
            moveModule.MoveStop(false);
            _moveModule.MoveToTarget(point);
        }
        
        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}