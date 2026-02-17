using System;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using TMPro;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.OneData
{
    public class KillCountDataUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        private StatSO _stat;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            if(_stat != null) _stat.OnValueChanged -= ChangedValue;
        }

        public void SetData(StatSO value)
        {
            if(_stat != null) _stat.OnValueChanged -= ChangedValue;
            
            _stat = value;

            if (_stat != null)
            {
                _stat.OnValueChanged += ChangedValue;
                _textMesh.text = "Kills : " + _stat.Value;
            }
        }

        private void ChangedValue(float value, float oldValue)
        {
            _textMesh.text = "Kills : " + value;
        }

        public void OnOff(bool value)
        {
            gameObject.SetActive(value);
        }
        
    }
}