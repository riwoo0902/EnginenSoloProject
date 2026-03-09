using System;
using _1.Script.EntityScript.Entities.FSM;
using _10.InputSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _1.Script.UI.ControlUI
{
    [RequireComponent(typeof(Button))]
    public class ControlChangeButton : MonoBehaviour
    {
        [SerializeField] private StateType changeState;
        public InputSO inputSo;
        public event Action<StateType> OnChangeState;


        public void InvokeButton()
        {
            OnChangeState?.Invoke(changeState);
        }
        
    }
}