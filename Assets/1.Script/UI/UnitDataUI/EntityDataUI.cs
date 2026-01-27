using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace _1.Script.UI.UnitDataUI
{
    public class EntityDataUI : AbstractUI
    {
        [SerializeField] private Entity showEntity;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            
            Debug.Assert(_image != null,"Image is null");
        }

        public override void UIOn()
        {
            gameObject.SetActive(true);    
        }

        public override void UIOff()
        { 
            gameObject.SetActive(false);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            EventBus<ChangeSelectedEntityData>.Raise(new ChangeSelectedEntityData(new List<Entity> {showEntity}));
        }
        
    }
}