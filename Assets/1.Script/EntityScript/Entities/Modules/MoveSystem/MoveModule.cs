using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;
using UnityEngine.AI;

namespace _1.Script.EntityScript.Entities.Modules.MoveSystem
{
    public interface IMoveModule
    {
        void MoveToTarget(Vector3 target);
        void SetSpeed(float speed);
    }

    public class MoveModule : MonoBehaviour, IModule, IMoveModule
    {
        private Entity _entity;
        private NavMeshAgent _navMeshAgent;
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            Debug.Assert(_entity != null, "This is not Entity");
            Debug.Assert(_entity.TryGetComponent(out _navMeshAgent),"NavMeshAgent component not found");
            
        }


        public void MoveToTarget(Vector3 target)
        {
            _navMeshAgent.SetDestination(target);
        }

        public void SetSpeed(float speed)
        {
            _navMeshAgent.speed = speed;
        }
        
        
    }
}