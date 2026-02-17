using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs
{
    public class MultiEntityDataManager : MonoBehaviour
    {
        public void On(List<Entity> datas)
        {
            gameObject.SetActive(true);
            
            
            
            
            
            Debug.Log("MultiDataShow");
        }
        
        public void Off()
        {
            gameObject.SetActive(false);
        }
        
    }
}