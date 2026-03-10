using System;
using _1.Script.EntityScript.Entities.UnitScript.Units.BuildingUnits;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace _1.Script.BT.Action
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "TrySpawn", story: "Try Spawn to [spawnBuildingUnit]", category: "Action", id: "b7085ae1fd24c5c0b054a09c06ac2d29")]
    public partial class TrySpawnAction : Unity.Behavior.Action
    {
        [SerializeReference] public BlackboardVariable<SpawnBuildingUnit> spawnBuildingUnit;

        protected override Status OnStart()
        {
            spawnBuildingUnit.Value.SpawnUnit();
            
            return Status.Success;
        }
        
        
    }
}

