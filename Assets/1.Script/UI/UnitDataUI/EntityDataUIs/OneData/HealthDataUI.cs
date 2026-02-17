using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using TMPro;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.OneData
{
    public class HealthDataUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        private HealthModule _healthModule;
        private StatSO _maxHpStat;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            if(_healthModule != null) _healthModule.OnHealthChange -= HealthModuleOnOnHealthChange;
            if(_maxHpStat != null) _maxHpStat.OnValueChanged -= ChangedMaxHp;
        }

        public void SetData(HealthModule healthModule,StatSO maxStat)
        {
            if(_healthModule != null) _healthModule.OnHealthChange -= HealthModuleOnOnHealthChange;
            if(_maxHpStat != null) _maxHpStat.OnValueChanged -= ChangedMaxHp;
            
            _healthModule = healthModule;
            _maxHpStat = maxStat;
            
            if(_healthModule != null) _healthModule.OnHealthChange += HealthModuleOnOnHealthChange;
            if(_maxHpStat != null) _maxHpStat.OnValueChanged += ChangedMaxHp;
            TextUpData();
        }

        private void HealthModuleOnOnHealthChange(float before, float current, float max)
        {
            TextUpData();
        }

        private void ChangedMaxHp(float value, float oldValue)
        {
            TextUpData();
        }

        private void TextUpData()
        {
            if(_healthModule != null && _maxHpStat != null) _textMesh.text = $"{_healthModule.Hp} / {_maxHpStat.Value}";
        }
        
        public void OnOff(bool value)
        {
            gameObject.SetActive(value);
        }
        
    }
}