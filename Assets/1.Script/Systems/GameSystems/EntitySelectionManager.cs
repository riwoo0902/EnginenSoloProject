using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _10.InputSystem;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntitySelectionManager : MonoSingleton<EntitySelectionManager>
    {
        [SerializeField] private List<Entity> selectedEntities = new();

        private EntitiesManager EntitiesManager => EntitiesManager.Instance;
        
        protected override void Awake()
        {
            base.Awake();
            
        }

        

        
        
        
        
    }
}