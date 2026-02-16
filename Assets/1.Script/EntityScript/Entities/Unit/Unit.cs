using _1.Script.EntityScript.Entities.StatSystem;

namespace _1.Script.EntityScript.Entities.Unit
{
    public abstract class Unit : Entity
    {
        protected IStatModule statModule;
        
        protected override void Awake()
        {
            base.Awake();
            statModule = GetModule<IStatModule>();
            
            
            
        }
        
        
    }
}