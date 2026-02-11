using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntitySelectionManager : MonoSingleton<EntitySelectionManager>
    {
        [SerializeField] private EventChannel uiChannel;

        [SerializeField] private int selectRange = 50;
        
        [SerializeField] private List<Entity> selectedEntities = new(90);

        private List<Entity> _entitiesList;
        
        private Camera _mainCamera;
        
        protected override void Awake()
        {
            base.Awake();
            _mainCamera = Camera.main;
            _entitiesList = EntitiesManager.Instance.entities;
            
            uiChannel.AddListener<MouseDragEndEvent>(DragEnd);
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<MouseDragEndEvent>(DragEnd);
            
        }

        private void DragEnd(MouseDragEndEvent evt)
        {
            selectedEntities.Clear();
            foreach (Entity entity in _entitiesList)
            {
                if (CheckSelection(entity, evt))
                {
                    selectedEntities.Add(entity);
                    entity.SelectEntity(true);
                    if(selectedEntities.Count >= 90) break;
                }
                else
                {
                    entity.SelectEntity(false);
                }
            }
        }

        private bool CheckSelection(Entity entity, MouseDragEndEvent evt)
        {
            Vector2 entityPos = _mainCamera.WorldToScreenPoint(entity.transform.position);

            if (evt.startPos.x - selectRange <= entityPos.x && entityPos.x <= evt.endPos.x + selectRange)
            {
                if (evt.startPos.y - selectRange <= entityPos.y && entityPos.y <= evt.endPos.y + selectRange)
                {
                    
                    return true;
                }
            }
            
            return false;
        }
        
    }
}