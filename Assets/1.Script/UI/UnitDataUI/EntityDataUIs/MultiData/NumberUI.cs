using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class NumberUI : MonoBehaviour
    {
        private Button _button;
        public int ShowPage { get; set; }
        public event Action<int> OnPageButtonClick;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnPointerClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void On()
        {
            gameObject.SetActive(true);
        }

        public void Off()
        {
            gameObject.SetActive(false);
        }

        private void OnPointerClick()
        {
            Debug.Log("Button Click");
            OnPageButtonClick?.Invoke(ShowPage);
        }
    }
}