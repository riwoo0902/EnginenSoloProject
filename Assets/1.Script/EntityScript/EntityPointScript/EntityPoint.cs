using System;
using UnityEngine;

namespace _1.Script.EntityScript.EntityPointScript
{
    public class EntityPoint : MonoBehaviour
    {
        [SerializeField] private Transform entityTarget;
        public bool IsHaveTarget => entityTarget != null;
        private Vector3 _pos;
        private const float PlusSize = 1.2f;

        private void Awake()
        {
            
        }

        private void FixedUpdate()
        {
            if(!IsHaveTarget) return;
            
            Vector3 position = entityTarget.position+ _pos;
            position.y = 0.55f;
            transform.position = position;
        }

        public void SetTarget(Transform target)
        {
            entityTarget = target;

            if (entityTarget != null)
            {
                gameObject.SetActive(true);
                Vector3 size = target.lossyScale;
                size.y = 0.05f;
                transform.localScale = size * PlusSize;
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
        
        
    }
}