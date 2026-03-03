using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using UnityEngine;

namespace _2.So._1.Scripts.ControlData.ControlSos
{
    [CreateAssetMenu(fileName = "StopControl", menuName = "Control Data/ControlSos/StopControl", order = 0)]
    public class StopControl : AbstractControlSo
    {
        public override void Control(Entity entity, IMoveModule moveModule, Vector3 point)
        {
            moveModule.MoveToTarget(entity.transform.position);
        }
    }
}