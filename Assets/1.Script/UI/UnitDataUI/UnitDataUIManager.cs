using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI
{
    public class UnitDataUIManager : MonoBehaviour
    {
        private List<Entity> _entities = new();
        private void Awake()
        {
            EventBus<ChangeSelectedEntityData>.OnEvent += ChangeSelectEntityData;
        }

        private void ChangeSelectEntityData(ChangeSelectedEntityData evt)
        {
            _entities = evt.selectedEntity;
        }

        private void OnDestroy()
        {
            EventBus<ChangeSelectedEntityData>.OnEvent -= ChangeSelectEntityData;
        }
    }
}