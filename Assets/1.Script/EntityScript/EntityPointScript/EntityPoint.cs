using UnityEngine;

namespace _1.Script.EntityScript.EntityPointScript
{
    public class EntityPoint : MonoBehaviour
    {
        [SerializeField] private Transform entityTarget;
        public bool IsHaveTarget => entityTarget != null;
        private Vector3 _pos;
        private const float PlusSize = 0.2f;
        
        private void FixedUpdate()
        {
            Vector3 position = entityTarget.position+ _pos;
            position.y = 0.55f;
            transform.position = position;
        }

        public void SetTarget(Transform target)
        {
            entityTarget = target;
            
            Vector3 size = target.lossyScale;
            size.y = 0.05f;
            transform.localScale = size * PlusSize;
        }
        
        
    }
}