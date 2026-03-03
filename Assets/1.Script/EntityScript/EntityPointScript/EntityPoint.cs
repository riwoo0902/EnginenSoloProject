using System;
using _1.Script.EntityScript.Entities;
using UnityEngine;

namespace _1.Script.EntityScript.EntityPointScript
{
    public class EntityPoint : MonoBehaviour
    {
        [SerializeField] private Entity entityTarget;
        public bool IsHaveTarget => entityTarget != null;
        private const float PlusSize = 1.2f;
        private const float YPosition = 0.55f;
        private void Awake()
        {
            
        }

        private void FixedUpdate()
        {
            if(!IsHaveTarget) return;
            
            Vector3 position = entityTarget.transform.position;
            position.y = YPosition;
            transform.position = position;
        }

        public void SetTarget(Entity target)
        {
            entityTarget = target;
            Vector3 size = target.transform.lossyScale;
            size.y = 0.05f;
            transform.localScale = size * PlusSize;

            entityTarget.Selection += Show;
        }

        public void RemoveTarget()
        {
            entityTarget.Selection -= Show;
            entityTarget = null;
            gameObject.SetActive(false);
        }

        private void Show(bool b)
        {
            gameObject.SetActive(b);
        }
        
        
        
        
    }
}