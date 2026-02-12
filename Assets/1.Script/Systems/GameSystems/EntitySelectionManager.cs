using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.Systems.GameSystems
{
    public class EntitySelectionManager : MonoSingleton<EntitySelectionManager>
    {
        [SerializeField] private InputSO inputs;
        [SerializeField] private EventChannel uiChannel;

        [SerializeField] private Vector2 selectSize = new Vector2(50,50);
        
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
            if (inputs.isShiftPressed)
            {
                ShiftDrag(evt);
            }
            else if (inputs.isAltPressed)
            {
                AltDrag(evt);
            }
            else
            {
                NormalDrag(evt);
            }
            
            uiChannel.RaiseEvent(UIEvents.EntitySelection.Init(selectedEntities));
        }

        #region Drag

        private void NormalDrag(MouseDragEndEvent evt)
        {
            selectedEntities.Clear();
            
            foreach (Entity entity in _entitiesList)
            {
                
                if (selectedEntities.Count < 90 && CheckSelection(entity, evt))
                {
                    selectedEntities.Add(entity);
                    entity.SelectEntity(true);
                }
                else
                {
                    entity.SelectEntity(false);
                }
            }
        }
        private void ShiftDrag(MouseDragEndEvent evt)
        {
            foreach (Entity entity in _entitiesList)
            {
                if (selectedEntities.Contains(entity))
                {
                    continue;
                }
                
                
                if (selectedEntities.Count < 90 && CheckSelection(entity, evt))
                {
                    selectedEntities.Add(entity);
                    entity.SelectEntity(true);
                }
                else
                {
                    entity.SelectEntity(false);
                }
            }
        }
        private void AltDrag(MouseDragEndEvent evt)
        {
            foreach (Entity entity in _entitiesList)
            {
                if (!selectedEntities.Contains(entity))
                {
                    continue;
                }
                
                if (CheckSelection(entity, evt))
                {
                    selectedEntities.Remove(entity);
                    entity.SelectEntity(false);
                }
                
            }
        }

        #endregion
        
        private bool CheckSelection(Entity entity, MouseDragEndEvent evt)
        {
            Vector2 entityPos = _mainCamera.WorldToScreenPoint(entity.transform.position);

            if (evt.startPos.x - selectSize.x <= entityPos.x && entityPos.x <= evt.endPos.x + selectSize.x)
            {
                if (evt.startPos.y - selectSize.y <= entityPos.y && entityPos.y <= evt.endPos.y + selectSize.y)
                {
                    
                    return true;
                }
            }
            
            return false;
        }
        
    }
}