namespace _1.Script.EntityScript.ModuleSystem
{
    public interface IModule
    {
        void Initialize(ModuleOwner owner);
        void AfterInitialize(){ }
        
    }
}