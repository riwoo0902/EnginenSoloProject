using System;
using _1.Script.EntityScript.Entities.UnitScript.Units.BuildingUnits;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace _1.Script.BT.Action
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "CheckSpawn", story: "Can Spawn to [buildUnit]", category: "Action", id: "9c9224d3e0e8e0ac1ed26a7c87c75f22")]
    public partial class CheckSpawnAction : Unity.Behavior.Action
    {
        [SerializeReference] public BlackboardVariable<SpawnBuildingUnit> buildUnit;

        private float _currentEnterTime;
        protected override Status OnStart()
        {
            _currentEnterTime = Time.time;
            
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            if (Time.time - _currentEnterTime > buildUnit.Value.Delay)
            {
                return Status.Success;
            }
            return Status.Running;
        }
        
    }
}

