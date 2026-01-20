using System.Collections.Generic;
using _1.Script.EntityScript.Entities;

namespace _1.Script.Systems.EventBusScript.Events
{
    public struct ChangeSelectedEntityData : IEvent
    {
        public List<Entity> selectedEntity;

        public ChangeSelectedEntityData(List<Entity> entitys)
        {
            selectedEntity = entitys;
        }
        
    }
}