using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _1.Script.EntityScript.Entities.UnitScript.Units
{
    public class MoveUnit : Unit
    {
        [SerializeField] private StateListSO stateListSo;
        public StateMachine StateMachine { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            StateMachine = new StateMachine(this,stateListSo.states);
        }

        protected override void Start()
        {
            base.Start();
            StateMachine.ChangeState(transform.position, StateType.AttackMove);
        }
        protected virtual void Update()
        {
            StateMachine.UpdateMachine();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.FixedUpdateMachine();
        }
    }
}