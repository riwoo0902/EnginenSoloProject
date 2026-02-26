using System;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class MainMoveCamera : MonoSingleton<MainMoveCamera>
    {
        [SerializeField] private InputSO inputSo;
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private float moveSpeed = 50;
        [SerializeField] private Transform mainCameraTrm;


        private void FixedUpdate()
        {
            transform.position = mainCameraTrm.position;
        }

        private void Update()
        {
            Vector2 moveVec = inputSo.CameraMoveDir * (moveSpeed * Time.deltaTime);
            transform.transform.position += new Vector3(moveVec.x, 0, moveVec.y);
            uiChannel.RaiseEvent(UIEvents.CameraMove.Init(moveVec));
            
        }
        
    }
}