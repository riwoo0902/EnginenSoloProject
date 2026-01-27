using UnityEngine;

namespace _2.So._1.Scripts.DataBase
{
    public abstract class IndexedAsset : ScriptableObject, IIndexed
    {
        [field:SerializeField] public int Index { get; set; }
        
    }

    public interface IIndexed
    {
        public int Index { get; set; }
    }
}