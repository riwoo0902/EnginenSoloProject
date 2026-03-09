using System;
using _1.Script.EntityScript.Entities.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace _1.Script.UI.ControlUI
{
    [RequireComponent(typeof(Button))]
    public class ControlChangeButton : MonoBehaviour
    {
        [SerializeField] private StateType changeState;
        public event Action<StateType> OnChangeState;


        private void InvokeButton()
        {
            OnChangeState?.Invoke(changeState);
        }
        
    }
}