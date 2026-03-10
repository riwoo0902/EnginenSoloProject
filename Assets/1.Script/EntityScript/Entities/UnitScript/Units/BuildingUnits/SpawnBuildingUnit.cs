using UnityEngine;

namespace _1.Script.EntityScript.Entities.UnitScript.Units.BuildingUnits
{
    public class SpawnBuildingUnit : BuildingUnit
    {
        [SerializeField] private GameObject _unitPrefab;
        [field:SerializeField] public float Delay { get; private set; } = 3;


        public void SpawnUnit()
        {
            GameObject unit = Instantiate(_unitPrefab);
            
        }
    }
}