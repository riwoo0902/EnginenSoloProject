using System;
using _1.Script.EntityScript.Entities.FSM;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.ControlUI
{
    public class ControlUIManager : MonoBehaviour
    {
        [SerializeField] private InputSO inputSo;
        [SerializeField] private EventChannel uiChannel;
        
        private ControlChangeButton[] _buttons;
        private void Awake()
        {
            _buttons = GetComponentsInChildren<ControlChangeButton>();
            foreach (ControlChangeButton controlChangeButton in _buttons)
            {
                controlChangeButton.OnChangeState += ChangeControlType;
            }

            inputSo.OnMovePressed += MoveControlKeyPressed;
            inputSo.OnStopPressed += StopControlKeyPressed;
            inputSo.OnAttackPressed += AttackMoveControlKeyPressed;
        }

        private void OnDestroy()
        {
            foreach (ControlChangeButton controlChangeButton in _buttons)
            {
                controlChangeButton.OnChangeState -= ChangeControlType;
            }
            
            inputSo.OnMovePressed -= MoveControlKeyPressed;
            inputSo.OnStopPressed -= StopControlKeyPressed;
            inputSo.OnAttackPressed -= AttackMoveControlKeyPressed;
        }

        private void ChangeControlType(StateType type)
        {
            uiChannel.RaiseEvent(UIEvents.ChangeEntityControl.Init(type));
        }

        private void MoveControlKeyPressed()
        {
            ChangeControlType(StateType.Move);
        }
        
        private void StopControlKeyPressed()
        {
            ChangeControlType(StateType.Stop);
        }
        
        private void AttackMoveControlKeyPressed()
        {
            ChangeControlType(StateType.AttackMove);
        }
        
    }
}