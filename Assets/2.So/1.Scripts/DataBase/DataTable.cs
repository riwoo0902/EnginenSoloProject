using UnityEngine;

namespace _2.So._1.Scripts.DataBase
{
    public abstract class DataTable<T> : ScriptableObject where T : IndexedAsset
    {
        //[field:SerializeField] public string TableName { get; private set; }
        [field:SerializeField] public T[] Datas { get; private set; }
        
        
        
    }
}