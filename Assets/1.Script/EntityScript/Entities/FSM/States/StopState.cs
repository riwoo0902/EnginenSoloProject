using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM.States
{
    public class StopState : AbstractState
    {
        public StopState(Entity owner) : base(owner)
        {
            
        }

        public override void Enter(Vector3 point)
        {
            moveModule.MoveStop(true);
        }
        
        public override void Update()
        {
            
        }

        public override void Exit()
        {
            moveModule.MoveStop(false);
        }
        
        
    }
}