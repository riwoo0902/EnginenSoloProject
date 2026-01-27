using UnityEngine;

namespace _2.So._1.Scripts.DataBase
{
    public abstract class DataTable : ScriptableObject
    {
        [field:SerializeField] public string TableName { get; private set; }
        [field:SerializeField] public IndexedAsset[] Datas { get; private set; }
        [field: SerializeField] private bool outoIndexed = false;
        private void OnValidate()
        {
            if (outoIndexed && Datas != null)
            {
                for (int i = 0; i < Datas.Length; i++)
                {
                    Datas[i].Index = i;
                }
            }
            
            
        }
        
        
    }
}