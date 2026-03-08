using _1.Script.EntityScript.Entities.FSM;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Test
{
    public class TestEventRaise : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;

        [ContextMenu("ChangeControlState_Stop")]
        public void ChangeControlState_Stop()
        {
            uiChannel.RaiseEvent(UIEvents.ChangeEntityControl.Init(StateType.Stop));
        }
        
        [ContextMenu("ChangeControlState_Move")]
        public void ChangeControlState_Move()
        {
            uiChannel.RaiseEvent(UIEvents.ChangeEntityControl.Init(StateType.Move));
        }
    }
}