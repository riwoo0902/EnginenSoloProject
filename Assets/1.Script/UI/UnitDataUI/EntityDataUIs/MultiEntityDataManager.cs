using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs
{
    public class MultiEntityDataManager : MonoBehaviour
    {
        
        [SerializeField] private NumberManager numberManager;
        
        public void On(List<Entity> data)
        {
            gameObject.SetActive(true);
            numberManager.SetData(data);
            
            
            
            
            
        }
        
        public void Off()
        {
            gameObject.SetActive(false);
        }
        
    }
}