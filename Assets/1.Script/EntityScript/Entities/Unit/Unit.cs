using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Unit
{
    public abstract class Unit : Entity
    {
        protected IStatModule statModule;
        
        private StateMachine _stateMachine;
        
        [SerializeField] private StateListSO stateListSo;
        
        protected override void Awake()
        {
            base.Awake();
            statModule = GetModule<IStatModule>();
            
            _stateMachine =  new StateMachine(this,stateListSo.states);
            
            //_stateMachine.ChangeState(PlayerStateEnum.);
        }


        protected virtual void Update()
        {
            _stateMachine.UpdateMachine();
        }
    }
}