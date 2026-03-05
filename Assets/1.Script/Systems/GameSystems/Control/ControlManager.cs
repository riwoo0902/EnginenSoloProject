using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.ControlListenerSystem;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.ControlData;
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
        [SerializeField] private ControlTable controlTable;
        
        private Camera _camera;
        private EventSystem _eventSystem;
        
        public AbstractControlSo currentControl;
        
        private readonly List<IControlListenerModule> _controlListenerModules = new();
        
        private bool _isPointerOverGameObject = false;
        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
            
            inputSo.OnMouseRightPressed += InvokeControl;
            uiChannel.AddListener<EntitySelectionEvent>(ControlListenerInput);
        }

        private void Update()
        {
            _isPointerOverGameObject = _eventSystem.IsPointerOverGameObject();
        }

        private void OnDestroy()
        {
            inputSo.OnMouseRightPressed -= InvokeControl;
            uiChannel.RemoveListener<EntitySelectionEvent>(ControlListenerInput);
        }

        private void ControlListenerInput(EntitySelectionEvent evt)
        {
            _controlListenerModules.Clear();

            foreach (Entity entity in evt.entities)
            {
                IControlListenerModule controlListenerModule = entity.GetModule<IControlListenerModule>();
                if (controlListenerModule != null)
                {
                    _controlListenerModules.Add(controlListenerModule);
                }
            }

        }
        
        private void InvokeControl()
        {
            if(_isPointerOverGameObject || currentControl.ControlType == ControlType.Now) return;
            
            Ray ray = _camera.ScreenPointToRay(inputSo.mouseUIPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100,groundLayer))
            {
                foreach (IControlListenerModule controlListenerModule in _controlListenerModules)
                {
                    controlListenerModule.Control(currentControl,hit.point);
                }
                uiChannel.RaiseEvent(UIEvents.SetPointer.Init(hit.point.ChangeToVector2()));
            }
        }
        
        
        
    }
}