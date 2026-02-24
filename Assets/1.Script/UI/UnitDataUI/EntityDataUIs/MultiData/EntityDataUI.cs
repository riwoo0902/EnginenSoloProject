using System;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using _1.Script.EntityScript.Entities.Modules.VisualSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class EntityDataUI : AbstractUI
    {
        public delegate void EntityDataUIClick(Entity page);
        public event EntityDataUIClick OnEntityDataUIClick;
        
        private Entity _entity;
        private HealthModule _healthModule;
        private Image _image;
        
        private Sprite _defaultSprite;

        private void Awake()
        {
            _image = GetComponent<Image>();
            
        }

        private void OnDisable()
        {
            if(_healthModule != null)_healthModule.OnHealthChange -= HealthModuleOnOnHealthChange;
        }

        public void SetData(Entity entity)
        {
            if(_healthModule != null)_healthModule.OnHealthChange -= HealthModuleOnOnHealthChange;
            _entity = entity;
            _healthModule = _entity.GetModule<HealthModule>();
            if (_healthModule != null)
            {
                _healthModule.OnHealthChange += HealthModuleOnOnHealthChange;
                _image.color = new Color(Math.Clamp(_healthModule.MaxHp/_healthModule.Hp-1,0,1),Math.Clamp(_healthModule.Hp/_healthModule.MaxHp * 2,0,1), 0, 1);
            }
            
            VisualModule visualModule = _entity.GetModule<VisualModule>();

            _image.sprite = (visualModule != null && visualModule.EntityIcon != null) ? visualModule.EntityIcon : _defaultSprite;

        }

        private void HealthModuleOnOnHealthChange(float before, float current, float max)
        {
            _image.color = new Color(Math.Clamp(max/current -1,0,1),Math.Clamp(current/max * 2,0,1), 0, 1);
        }

        public void SetDefaultSprite(Sprite sprite)
        {
            _defaultSprite = sprite;
        }
        public override void On()
        {
            gameObject.SetActive(true);
        }

        public override void Off()
        {
            gameObject.SetActive(false);
        }

        public override void OnPointerEnter(PointerEventData eventData) { }
        public override void OnPointerClick(PointerEventData eventData)
        {
            OnEntityDataUIClick?.Invoke(_entity);
        }
    }
}