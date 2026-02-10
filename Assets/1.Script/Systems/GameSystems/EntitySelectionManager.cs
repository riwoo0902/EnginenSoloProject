using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntitySelectionManager : MonoSingleton<EntitySelectionManager>
    {
        [SerializeField] private List<Entity> selectedEntities = new();
        
        protected override void Awake()
        {
            base.Awake();
            
        }



        
        
        
        
    }
}