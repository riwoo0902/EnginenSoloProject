using _1.Script.EntityScript.Module;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;

namespace _1.Script.EntityScript.Entities
{
    public abstract class Entity : ModuleOwner
    {
        protected override void Awake()
        {
            base.Awake();
            
            EventBus<EntitySpawn>.Raise(new EntitySpawn(this));
            
        }
        
        
    }
}