using _10.InputSystem;
using UnityEngine;

namespace _1.Script.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveTest : MonoBehaviour
    {
        [SerializeField] private InputSo input;
        [SerializeField] private float moveSpeed;

        private Rigidbody _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigid.linearVelocity = input.MoveDir * moveSpeed;
        }
    }
}
