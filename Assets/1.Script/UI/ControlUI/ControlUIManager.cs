using System;
using _1.Script.EntityScript.Entities.FSM;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.ControlUI
{
    public class ControlUIManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;

        private ControlChangeButton[] _buttons;
        private void Awake()
        {
            _buttons = GetComponentsInChildren<ControlChangeButton>();
            foreach (ControlChangeButton controlChangeButton in _buttons)
            {
                controlChangeButton.OnChangeState += ChangeControlType;
            }
        }

        private void OnDestroy()
        {
            foreach (ControlChangeButton controlChangeButton in _buttons)
            {
                controlChangeButton.OnChangeState -= ChangeControlType;
            }
        }

        private void ChangeControlType(StateType type)
        {
            uiChannel.RaiseEvent(UIEvents.ChangeEntityControl.Init(type));
        }
        
        
    }
}