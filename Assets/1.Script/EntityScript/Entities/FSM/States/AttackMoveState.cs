using _1.Script.EntityScript.Entities.Modules.AttackSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM.States
{
    public class AttackMoveState : AbstractState
    {
        private IAttackSenserModule _attackSenserModule;
        public AttackMoveState(Entity owner) : base(owner)
        {
            Debug.Assert(owner.TryGetModule(out _attackSenserModule),"AttackSenser is not found");
            
            
        }

        private Vector3 _targetPos;
        public override void Enter(Vector3 point)
        {
            _targetPos = point;
            
        }
        
        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}