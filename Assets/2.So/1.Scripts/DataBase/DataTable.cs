using UnityEngine;

namespace _2.So._1.Scripts.DataBase
{
    public abstract class DataTable : ScriptableObject
    {
        [field:SerializeField] public string TableName { get; private set; }
        [field:SerializeField] public IndexedAsset[] Datas { get; private set; }

        private void OnValidate()
        {
            for (int i = 0; i < Datas.Length; i++) Datas[i].index = i;
            
            
        }
        
        
    }
}