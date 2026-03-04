using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM
{
    [CreateAssetMenu(fileName = "State data", menuName = "FSM/State data", order = 0)]
    public class StateSO : ScriptableObject
    {
        public string stateName;
        public string className;
        public int stateIndex;

        [ContextMenu("Debug ClassName")]
        public void DebugClassName()
        {
            Debug.Log(className);
        }
    }
}