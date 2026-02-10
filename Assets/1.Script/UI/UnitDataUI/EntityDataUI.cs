using _1.Script.EntityScript.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI.UnitDataUI
{
    public class EntityDataUI : AbstractUI
    {
        [SerializeField] private Entity showEntity;

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
            
        }
        
    }
}