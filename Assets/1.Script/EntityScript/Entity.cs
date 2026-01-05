using System;
using _1.Script.CollisionManagerScript;
using _1.Script.NotifyValueScript;
using UnityEngine;
using UnityEngine.UIElements;

namespace _1.Script.EntityScript
{
    [RequireComponent(typeof(Collider))]
    public class Entity : MonoBehaviour,ICanCollision
    {
        private Collider _collider;
        
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            if (CollisionManage<Entity>.TryAddPool(_collider, this))
            {
                
            }
            else
            {
                Debug.Log("Error");
            }
        }

        private void OnDestroy()
        {
            CollisionManage<Entity>.RemovePool(_collider);
        }
        
    }
}