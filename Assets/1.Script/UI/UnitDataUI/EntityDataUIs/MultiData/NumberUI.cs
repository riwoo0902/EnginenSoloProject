using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class NumberUI : AbstractUI
    {
        public int ShowPage { get; set; }
        public event Action<int> OnPageButtonClick;

        public override void On()
        {
            
        }

        public override void Off()
        {
            
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            OnPageButtonClick?.Invoke(ShowPage);
        }
    }
}