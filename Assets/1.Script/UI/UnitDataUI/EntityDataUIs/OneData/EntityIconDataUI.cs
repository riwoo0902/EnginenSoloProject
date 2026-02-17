using System;
using _1.Script.EntityScript.Entities.Modules.VisualSystem;
using UnityEngine;
using UnityEngine.UI;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.OneData
{
    public class EntityIconDataUI : MonoBehaviour
    {
        [SerializeField] private Sprite defaultIcon;
        private Image _icon;

        private void Awake()
        {
            _icon = GetComponent<Image>();
        }

        public void SetSprite(Sprite icon)
        {
            _icon.sprite = icon != null ? icon : defaultIcon;
        }

        public void OnOff(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}