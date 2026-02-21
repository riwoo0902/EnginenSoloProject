using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class MultiDataUIManager : MonoBehaviour
    {
        private EntityDataUI[] entityDataUIs;
        private void Awake()
        {
            entityDataUIs = GetComponentsInChildren<EntityDataUI>();
            
            
        }

        public void SetData(List<Entity> data)
        {
            for (int i = 0; i < entityDataUIs.Length; i++)
            {
                if (data.Count <= i)
                {
                    entityDataUIs[i].Off();
                }
                else
                {
                    entityDataUIs[i].SetData(data[i]);
                    entityDataUIs[i].On();
                }
            }
        }
        
        
        
        
        
        
    }
}