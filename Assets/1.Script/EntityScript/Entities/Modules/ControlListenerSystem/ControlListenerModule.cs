using System;
using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.UnitScript;
using _1.Script.EntityScript.ModuleSystem;
using _2.So._1.Scripts;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.ControlListenerSystem
{
    public interface IControlListenerModule
    {
        public void Control(Vector3 point,StateType currentControl);
    }
    public class ControlListenerModule : MonoBehaviour,IModule,IControlListenerModule
    {
        private Unit _entity;
        private StateMachine _stateMachine;
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Unit;
            Debug.Assert(_entity != null,"Module owner is not Entity");
        }

        private void Start()
        {
            _stateMachine = _entity.StateMachine;
        }

        public void Control(Vector3 point,StateType currentControl)
        {
            _stateMachine.ChangeState(point,currentControl);
        }
        
    }
}