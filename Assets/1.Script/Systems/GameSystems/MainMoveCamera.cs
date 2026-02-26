using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    [RequireComponent(typeof(Camera))]
    public class MainMoveCamera : MonoSingleton<MainMoveCamera>
    {
        [SerializeField] private InputSO inputSo;
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private float moveSpeed = 1;

        private void Update()
        {
            Vector2 moveVec = inputSo.CameraMoveDir * moveSpeed;
            transform.transform.position += new Vector3(moveVec.x, 0, moveVec.y);
            uiChannel.RaiseEvent(UIEvents.CameraMove.Init(moveVec));
        }
        
        
    }
}