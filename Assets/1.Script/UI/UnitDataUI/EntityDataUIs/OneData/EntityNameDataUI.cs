using System;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.OneData
{
    public class EntityNameDataUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string value)
        {
            _textMesh.text = value;
        }

        public void OnOff(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}