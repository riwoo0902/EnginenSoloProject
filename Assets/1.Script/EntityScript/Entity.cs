using _1.Script.CollisionManagerScript;
using _1.Script.UserScript.DragManagerScript;
using UnityEngine;

namespace _1.Script.EntityScript
{
    public class Entity : MonoBehaviour
    {
        private void Awake()
        {
            EntityManager.Entities.Add(this);
        }

        private void OnDestroy()
        {
            EntityManager.Entities.Remove(this);
        }
        
    }
}