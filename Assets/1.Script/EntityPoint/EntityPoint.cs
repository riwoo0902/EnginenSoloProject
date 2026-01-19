using _1.Script.EntityScript.Module;
using UnityEngine;

namespace _1.Script.EntityPoint
{
    public class EntityPoint : MonoBehaviour
    {
        private Transform _target;
        public bool IsHaveTarget => _target != null;

        private void FixedUpdate()
        {
            
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
        
    }
}