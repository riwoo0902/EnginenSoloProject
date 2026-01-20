using _1.Script.EntityScript;
using _1.Script.EntityScript.Entities;

namespace _1.Script.Systems.EventBusScript.Events
{
    public struct EntitySpawn : IEvent
    {
        public Entity entity;

        public EntitySpawn(Entity entity)
        {
            this.entity = entity;
        }
    }
}