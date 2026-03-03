namespace _1.Script.EntityScript.Entities.FSM
{
    public abstract class AbstractState
    {
        protected Entity entity;
        
        public AbstractState(Entity owner)
        {
            entity = owner;
        }

        public abstract void Update();

        public abstract void Enter();

        public abstract void Exit();

    }
}