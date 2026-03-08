using System;
using System.Collections.Generic;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM
{
    public class StateMachine
    {
        public AbstractState CurrentState { get; private set; }

        private Dictionary<StateType, AbstractState> _stateDict;

        public StateMachine(Entity owner, StateSO[] stateList)
        {
            _stateDict = new Dictionary<StateType, AbstractState>();

            foreach (StateSO state in stateList)
            {
                Type type = Type.GetType(state.className); //해당 클래스 이름을 기반으로 타입정보를 가져온다.
                Debug.Assert(type != null, $"State class not found: {state.className}");
                
                AbstractState abstractState = Activator.CreateInstance(type, new object[]{owner}) as AbstractState;
                
                _stateDict.Add((StateType)state.stateIndex, abstractState);
            }
        }

        public void ChangeState(Vector3 point,StateType nextStateIndex)
        {
            CurrentState?.Exit();
            
            AbstractState nextState = _stateDict.GetValueOrDefault(nextStateIndex);
            Debug.Assert(nextState != null, $"State not found: {nextStateIndex}");
            
            CurrentState = nextState;
            CurrentState.Enter(point);
        }
        
        public void UpdateMachine() => CurrentState?.Update();
    }
}