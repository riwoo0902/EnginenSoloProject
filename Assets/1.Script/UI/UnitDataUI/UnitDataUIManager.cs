using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.UI.UnitDataUI.EntityDataUIs;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI
{
    public class UnitDataUIManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        
        [SerializeField] private OneEntityDataManager oneEntityDataUI;
        [SerializeField] private MultiEntityDataManager multiEntityDataUI;

        
        private void Awake()
        {
            uiChannel.AddListener<EntitySelectionEvent>(ShowEntityData);
        }

        private void Start()
        {
            multiEntityDataUI.Off();
            oneEntityDataUI.Off();
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<EntitySelectionEvent>(ShowEntityData);
        }
        
        private void ShowEntityData(EntitySelectionEvent evt)
        {
            if (evt.entities.Count > 1)
            {
                multiEntityDataUI.On(evt.entities);
                oneEntityDataUI.Off();
            }
            else if (evt.entities.Count == 1)
            {
                multiEntityDataUI.Off();
                oneEntityDataUI.On(evt.entities[0]);
            }
            else
            {
                multiEntityDataUI.Off();
                oneEntityDataUI.Off();
            }
            
        }

        
    }
}