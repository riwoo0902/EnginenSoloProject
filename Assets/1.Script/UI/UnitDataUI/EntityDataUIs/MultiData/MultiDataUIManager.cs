using System;
using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.Entities;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class MultiDataUIManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private Sprite defaultSprite;
        private EntityDataUI[] _entityDataUIs;
        
        private void Awake()
        {
            _entityDataUIs = GetComponentsInChildren<EntityDataUI>();
            foreach (EntityDataUI entityDataUI in _entityDataUIs)
            {
                entityDataUI.SetDefaultSprite(defaultSprite);
                entityDataUI.OnEntityDataUIClick += HandleDataUIClick;
            }
                
        }

        private void OnDestroy()
        {
            foreach (EntityDataUI entityDataUI in _entityDataUIs)
            {
                entityDataUI.OnEntityDataUIClick -= HandleDataUIClick;
            }
        }

        private void HandleDataUIClick(Entity page)
        {
            foreach (EntityDataUI dataUI in _entityDataUIs)
            {
                if(dataUI.Entity == null ||dataUI.Entity == page) continue;
                
                dataUI.Entity.SelectEntity(false);
            }
            uiChannel.RaiseEvent(UIEvents.EntitySelection.Init(new List<Entity> {page}));
        }

        public void SetData(List<Entity> data)
        {
            for (int i = 0; i < _entityDataUIs.Length; i++)
            {
                if (data.Count <= i)
                {
                    _entityDataUIs[i].Off();
                }
                else
                {
                    _entityDataUIs[i].SetData(data[i]);
                    _entityDataUIs[i].On();
                }
            }
        }
        
        
        
        
        
        
    }
}