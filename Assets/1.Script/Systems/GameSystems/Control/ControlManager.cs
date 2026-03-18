using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.ControlListenerSystem;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.Systems.GameSystems.Control
{
    public class ControlManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private InputSO inputSo;
        [SerializeField] private LayerMask groundLayer;
        
        private Camera _camera;
        private EventSystem _eventSystem;
        
        public StateType currentControl;
        
        private readonly List<IControlListenerModule> _controlListenerModules = new();
        
        private bool _isPointerOverGameObject = false;
        
        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
            
            inputSo.OnMouseRightPressed += InvokeMouseControl;
            uiChannel.AddListener<EntitySelectionEvent>(ControlListenerInput);
            uiChannel.AddListener<ChangeEntityControlEvent>(ChangeControlType);

        }

        private void Update()
        {
            _isPointerOverGameObject = _eventSystem.IsPointerOverGameObject();
        }

        private void OnDestroy()
        {
            inputSo.OnMouseRightPressed -= InvokeMouseControl;
            uiChannel.RemoveListener<EntitySelectionEvent>(ControlListenerInput);
            uiChannel.RemoveListener<ChangeEntityControlEvent>(ChangeControlType);
        }

        private void ControlListenerInput(EntitySelectionEvent evt)
        {
            _controlListenerModules.Clear();

            foreach (Entity entity in evt.entities)
            {
                if (entity.TryGetModule(out IControlListenerModule controlListenerModule))
                {
                    _controlListenerModules.Add(controlListenerModule);
                }
            }

        }

        public void ChangeControlType(ChangeEntityControlEvent evt)
        {
            if (evt.controlType == StateType.Stop)
            {
                foreach(IControlListenerModule listenerModule in _controlListenerModules)
                {
                    if(listenerModule == null) continue;
                    listenerModule.Control(Vector3.zero, evt.controlType);
                }
                return;
            }
            
            currentControl = evt.controlType;
        }
        
        private void InvokeMouseControl()
        {
            if(_isPointerOverGameObject || currentControl == StateType.Stop) return;
            
            Ray ray = _camera.ScreenPointToRay(inputSo.mouseUIPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100,groundLayer))
            {
                _controlListenerModules.ForEach(listenerModule => listenerModule.Control(hit.point, currentControl));
                uiChannel.RaiseEvent(UIEvents.SetPointer.Init(hit.point.ChangeToVector2(),currentControl));
                return;
            }
            
        }
        
        
        
    }
}