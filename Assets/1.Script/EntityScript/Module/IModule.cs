namespace _1.Script.EntityScript.Module
{
    public interface IModule
    {
        void Initialize(ModuleOwner owner);
        void AfterInitialize(){ }
        
    }
}