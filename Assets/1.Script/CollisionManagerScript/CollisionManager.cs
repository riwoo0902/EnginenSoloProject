using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _1.Script.CollisionManagerScript
{
    public static class CollisionManage<T> where T : ICanCollision
    {
        private static readonly Dictionary<Collider, T> Colliders = new();

        public static bool TryAddPool(Collider collider, T t)
        {
            if(collider == null || t == null) return false;
            return Colliders.TryAdd(collider, t);
        }
        
        public static void RemovePool(Collider collider)
        {
            if(collider == null) return;
            Colliders.Remove(collider);
        }   

        public static bool TryGetPool(Collider collider, out T t)
        {
            return Colliders.TryGetValue(collider, out t);
        }

        public static bool HasPool(Collider collider)
        {
            return Colliders.ContainsKey(collider);
        }

        public static List<T> TryGetPoolAll(Collider[] colliders)
        {
            List<T> result = new List<T>();
            foreach (Collider value in colliders)
            {
                if (TryGetPool(value, out T t))
                {
                    result.Add(t);
                }
            }
            return result;
        }
        public static void TryGetPoolAll(Collider[] colliders,List<T> result)
        {
            result ??= new List<T>();
            
            result.Clear();
            foreach (Collider value in colliders)
            {
                if (TryGetPool(value, out T t))
                {
                    result.Add(t);
                }
            }
            
        }
        public static int Count => Colliders.Count;
        
    }

    public interface ICanCollision
    {
        
    }
}