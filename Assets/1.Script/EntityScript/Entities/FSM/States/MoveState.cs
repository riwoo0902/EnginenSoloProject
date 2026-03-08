using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM.States
{
    public class MoveState : AbstractState
    {
        private IMoveModule _moveModule;
        public MoveState(Entity owner) : base(owner)
        {
            _moveModule = owner.GetModule<IMoveModule>();
        }
        
        public override void Enter(Vector3 point)
        {
            _moveModule.MoveToTarget(point);
        }
        
        public override void Update()
        {
            
        }
        
        public override void Exit()
        {
            
        }
    }
}