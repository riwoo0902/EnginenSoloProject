using System;
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
        
        public Action<Vector3> onControl;
        
        
        
        private void Awake()
        {
            _camera = Camera.main;
            inputSo.OnMouseRightPressed += InvokeControl;
            uiChannel.AddListener<EntitySelectionEvent>(ControlSend);
        }
        
        private void OnDestroy()
        {
            inputSo.OnMouseRightPressed -= InvokeControl;
            uiChannel.RemoveListener<EntitySelectionEvent>(ControlSend);
        }

        private void ControlSend(EntitySelectionEvent evt)
        {
            
        }
        
        private void InvokeControl()
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            
            Ray ray = _camera.ScreenPointToRay(inputSo.mouseUIPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100,groundLayer))
            {
                Control(hit.point);
            }
        }
        
        private void Control(Vector3 vec)
        {
            Debug.Log(vec);
            onControl?.Invoke(vec);
        }
        
        
    }
}