using UnityEngine;

namespace _1.Script.Lrw.MonoSingelton
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected bool DontDestroyLoadObject = false;
        private static T _instance;
        
        public static T Instance
        {
            get
            {
                SetInstance();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        
        private static void SetInstance()
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    Debug.Log($"{singleton.name} : {Time.time}");
                    _instance = singleton.AddComponent<T>();
                }
                if (Application.isPlaying &&_instance.DontDestroyLoadObject)
                {
                    _instance.transform.SetParent(null);
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }
        }
        
        protected virtual void Awake()
        {
            SetInstance();
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        protected virtual void OnApplicationQuit()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        
    }
}