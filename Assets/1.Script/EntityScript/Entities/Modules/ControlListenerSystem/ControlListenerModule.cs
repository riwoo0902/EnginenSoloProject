using System;
using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using _1.Script.EntityScript.ModuleSystem;
using _1.Script.Systems.GameSystems.Control;
using _2.So._1.Scripts.ControlData;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.ControlListenerSystem
{
    public interface IControlListenerModule
    {
        void Control(AbstractControlSo currentControl, Vector3 point);
    }
    public class ControlListenerModule : MonoBehaviour,IModule,IControlListenerModule
    {
        private Entity _entity;
        private IMoveModule _moveModule;
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            Debug.Assert(_entity != null,"Module owner is not Entity");
            
            _moveModule = _entity.GetModule<IMoveModule>();
            Debug.Assert(_moveModule != null,"MoveModule is not found");
        }

        public void Control(AbstractControlSo currentControl, Vector3 point)
        {
            currentControl.Control(_entity,_moveModule,point);
        }
        
    }
}