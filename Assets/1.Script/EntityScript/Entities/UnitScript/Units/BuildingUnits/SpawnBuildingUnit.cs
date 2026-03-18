using _1.Script.Systems;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.UnitScript.Units.BuildingUnits
{
    public class SpawnBuildingUnit : BuildingUnit
    {
        [SerializeField] private GameObject unitPrefab;
        [field:SerializeField] public float Delay { get; private set; } = 3;


        public void SpawnUnit()
        {
            GameObject unit = Instantiate(unitPrefab,transform);
            Vector3 pos = transform.position + (Random.insideUnitCircle.normalized.ChangeToVector3() * 3f);
            pos.y = 1.5f;
            unit.transform.position = pos;
            if (unit.TryGetComponent(out Entity entity))
            {
                entity.SetTeam(myTeam);
            }
        }
        
        
    }
}