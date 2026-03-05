using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities.FSM;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.AttackCaster
{
    public interface ICanUseColliderManager
    {
        
    }
    public static class ColliderManager
    {
        public static readonly Dictionary<Type,Dictionary<Collider,ICanUseColliderManager>> Colliders = new();

        public static void Push<T>(Collider collider,T input) where T : class , ICanUseColliderManager
        {
            Type type = typeof(T);
            
            Colliders.TryAdd(type, new Dictionary<Collider, ICanUseColliderManager>());
            
            Colliders[type].Add(collider, input);
        }

        public static bool Get<T>(Collider collider,out T returnValue) where T : class, ICanUseColliderManager
        {
            returnValue = null;
            
            if (Colliders.TryGetValue(typeof(T),out Dictionary<Collider, ICanUseColliderManager> colliders))
            {
                if (colliders.TryGetValue(collider, out ICanUseColliderManager input))
                {
                    returnValue = input as T;
                    return true;
                }
            }

            return false;
        }
        
        public static void Remove<T>(Collider collider) where T : class, ICanUseColliderManager
        {
            if (Colliders.TryGetValue(typeof(T),out Dictionary<Collider, ICanUseColliderManager> colliders))
            {
                colliders.Remove(collider);
            }
        }
        
    }
}