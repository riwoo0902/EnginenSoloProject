using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.Systems;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.UnitScript
{
    public class Unit : Entity
    {
        protected IStatModule statModule;
        
        public StateMachine StateMachine { get; private set; }
        
        [SerializeField] private StateListSO stateListSo;
        
        protected override void Awake()
        {
            base.Awake();
            statModule = GetModule<IStatModule>();
            
            StateMachine = new StateMachine(this,stateListSo.states);
        }

        protected override void Start()
        {
            base.Start();
            StateMachine.ChangeState(Vector2.zero, StateType.Stop);
        }


        protected virtual void Update()
        {
            StateMachine.UpdateMachine();
        }
        
    }
}