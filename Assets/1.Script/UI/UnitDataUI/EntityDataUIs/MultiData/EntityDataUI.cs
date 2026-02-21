using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class EntityDataUI : AbstractUI
    {
        private Entity _entity;
        private HealthModule _healthModule;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            
        }

        public void SetData(Entity entity)
        {
            _entity = entity;
            _healthModule = _entity?.GetModule<HealthModule>();
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
            Debug.Log(_entity.gameObject.name);
        }
    }
}