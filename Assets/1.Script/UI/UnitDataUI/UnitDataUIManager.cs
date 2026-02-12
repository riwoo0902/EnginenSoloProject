using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _2.So._1.Scripts;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI
{
    public class UnitDataUIManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        
        private List<Entity> _entities = new();
        
        private void Awake()
        {
            
        }
        
        
    }
}