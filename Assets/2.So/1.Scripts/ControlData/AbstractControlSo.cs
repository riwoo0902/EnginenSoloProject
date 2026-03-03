using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using _2.So._1.Scripts.DataBase;
using UnityEngine;

namespace _2.So._1.Scripts.ControlData
{
    public abstract class AbstractControlSo : IndexedAsset
    {
        [field:SerializeField] public ControlType ControlType { get; private set; } = ControlType.PointClick;
        public abstract void Control(Entity entity,IMoveModule moveModule,Vector3 point);
    }

    public enum ControlType
    {
        PointClick,Now
    }
}