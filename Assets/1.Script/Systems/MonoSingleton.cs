using System;
using UnityEngine;

namespace _1.Script.Systems
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object LockObject = new object();
        private static T _instance = null;
        
        public static T Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (_instance == null )
                    {
                        _instance = FindAnyObjectByType<T>();
                        if(_instance != null) return _instance;
                        _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if(Instance != this) Destroy(gameObject);
        }

        protected virtual void OnDisable()
        {
            _instance = null;
        }

        [ContextMenu("Singleton Check")]
        private void SingletonCheck()
        {
            if (_instance != null)
            {
                Debug.Log($"_instance is {typeof(T).Name}");
            }
            else
            {
                Debug.LogError("instance is null");
            }
        }
        
    }
}