using System;
using _2.So._1.Scripts;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class NumberManager : MonoBehaviour
    {
        [SerializeField] private EventChannel eventChannel;
        
        private NumberUI[] _numberUIs;

        private void Awake()
        {
            _numberUIs = GetComponentsInChildren<NumberUI>();
            for (int i = 0; i < _numberUIs.Length; i++)
            {
                _numberUIs[i].ShowPage = i;
                _numberUIs[i].OnPageButtonClick += PageChange;
            }
            
            
        }

        private void OnDestroy()
        {
            foreach (NumberUI numberUI in _numberUIs)
            {
                numberUI.OnPageButtonClick -= PageChange;
            }
        }

        private void PageChange(int page)
        {
            
        }
    }
}