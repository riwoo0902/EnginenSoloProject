using _10.InputSystem;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    [RequireComponent(typeof(Camera))]
    public class MainMoveCamera : MonoSingleton<MainMoveCamera>
    {
        [SerializeField] private InputSO inputSo;
        
        
    }
}