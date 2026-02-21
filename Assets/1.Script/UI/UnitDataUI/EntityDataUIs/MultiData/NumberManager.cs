using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.MultiData
{
    public class NumberManager : MonoBehaviour
    {
        [SerializeField] private EventChannel eventChannel;
        [SerializeField] private MultiDataUIManager multiDataUIManager;
        
        private NumberUI[] _numberUIs;
        
        private Dictionary<int,List<Entity>> _numberUIsDict = new();
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
        
        
        public void SetData(List<Entity> entities,int groupSize = 18)
        {
            _numberUIsDict.Clear();
            int currentIndex = 0;
            int count = 0;

            foreach (Entity data in entities)
            {
                if (_numberUIsDict.TryGetValue(currentIndex, out List<Entity> list))
                {
                    list.Add(data);
                }
                else
                {
                    _numberUIsDict.Add(currentIndex, new List<Entity> { data });
                }

                count++;
                if (count >= groupSize)
                {
                    currentIndex++;
                    count = 0;
                }
            }

            SetViewSetting(entities.Count);
            PageChange(0);
        }

        private void SetViewSetting(int entitiesAmount)
        {
            int count = 0;
            foreach (NumberUI numberUI in _numberUIs)
            {
                if (count < entitiesAmount)
                {
                    numberUI.On();
                }
                else
                {
                    numberUI.Off();
                }
                count += 18;
            }
        }

        private void PageChange(int page)
        {
            Debug.Log(page);
            multiDataUIManager.SetData(_numberUIsDict[page]);
        }
        
        
    }
}