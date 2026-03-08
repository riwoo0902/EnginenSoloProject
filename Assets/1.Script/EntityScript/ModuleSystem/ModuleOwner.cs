using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _1.Script.EntityScript.ModuleSystem
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, IModule> _moduleDict;

        protected virtual void Awake()
        {
            _moduleDict = GetComponentsInChildren<IModule>().ToDictionary(module => module.GetType());
            InitializeComponents();
            AfterInitComponents();
        }
        
        protected virtual void InitializeComponents()
        {
            foreach (IModule module in _moduleDict.Values)    
            {
                module.Initialize(this);
            }    
        }
        
        protected virtual void AfterInitComponents()
        {
            foreach (IModule afterInitModule in _moduleDict.Values)
            {
                afterInitModule.AfterInitialize();
            }
        }

        public T GetModule<T>()
        {
            if (_moduleDict.TryGetValue(typeof(T), out IModule module))
            {
                return (T)module;
            }
            
            IModule findModule = _moduleDict.Values.FirstOrDefault(moduleType => moduleType is T);
            if(findModule is T castedModule)
            {
                return castedModule;
            }
            return default;
        }
        
        public bool TryGetModule<T>(out T module)
        {
            module = GetModule<T>();
            return module != null;
        }
        
    }
}