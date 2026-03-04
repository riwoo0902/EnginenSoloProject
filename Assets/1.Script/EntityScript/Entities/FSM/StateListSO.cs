using UnityEngine;

namespace _1.Script.EntityScript.Entities.FSM
{
    [CreateAssetMenu(fileName = "FSM state manager", menuName = "FSM/State list", order = 10)]
    public class StateListSO : ScriptableObject
    {
        public string enumName;
        public StateSO[] states;
    }
}