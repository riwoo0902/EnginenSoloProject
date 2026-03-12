using UnityEngine;

namespace _2.So._1.Scripts
{
    [CreateAssetMenu(fileName = "Save id", menuName = "System/Save id", order = 0)]
    public class SaveIdData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [SerializeField, TextArea] private string description;
    }
}