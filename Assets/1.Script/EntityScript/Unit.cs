using UnityEngine;

namespace _1.Script.EntityScript
{
    public class Unit : MonoBehaviour
    {
        private void Awake()
        {
            UnitManager.Entities.Add(this);
        }

        private void OnDestroy()
        {
            UnitManager.Entities.Remove(this);
        }
        
    }
}