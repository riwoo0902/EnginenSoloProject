using _1.Script.EntityScript.Entities.Modules.AttackSystem;
using _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem;
using _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills;
using _1.Script.EntityScript.Entities.UnitScript;
using _1.Script.EntityScript.Entities.UnitScript.Units;
using _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM.States
{
    public class AttackMoveState : AbstractState
    {
        private IAttackSenserModule _attackSenserModule;
        private SkillModule _skillModule;
        private bool _canAttackMove;
        public AttackMoveState(MoveUnit owner) : base(owner)
        {
            _canAttackMove = owner.TryGetModule(out _attackSenserModule) && owner.TryGetModule(out _skillModule);
            
        }

        private Vector3 _targetPos;
        public override void Enter(Vector3 point)
        {
            _targetPos = point;
            
            if (!_canAttackMove)
            {
                moveUnit.StateMachine.ChangeState(point,StateType.Move);
            }
            
            
        }
        
        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            if (_attackSenserModule.TryGetTarget(out Entity target) &&
                _skillModule.TryGetSkill(out NormalAttackSkill skill))
            {
                moveModule.MoveStop(true);
                if (skill.CanUseSkill())
                {
                    skill.SetTarget(target.transform);
                    skill.UseSkill();
                }
            }
            else
            {
                moveModule.MoveStop(false);
                moveModule.MoveToTarget(_targetPos);
            }
        }

        public override void Exit()
        {
            moveModule.MoveStop(false);
        }
    }
}