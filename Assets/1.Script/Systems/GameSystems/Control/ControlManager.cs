using System;
using _10.InputSystem;
using UnityEngine;

namespace _1.Script.Systems.GameSystems.Control
{
    public class ControlManager : MonoBehaviour
    {
        [SerializeField] private InputSO inputSo;
        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        

        /*public Vector3 GetMousePointToWorldPoint()
        {
            Ray ray = _camera.ScreenPointToRay(inputSo.mouseUIPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
            }
            
            return hit.point;
        }*/
        
        
    }
}