using System;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.ModuleSystem;
using UnityEngine;
using UnityEngine.AI;

namespace _1.Script.EntityScript.Entities.Modules.MoveSystem
{
    public interface IMoveModule
    {
        void MoveToTarget(Vector3 target);
        public void MoveStop(bool stop);
    }

    public class MoveModule : MonoBehaviour, IModule, IMoveModule
    {
        private Entity _entity;
        private NavMeshAgent _navMeshAgent;
        private StatSO _speedStat;
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            Debug.Assert(_entity != null, "This is not Entity");
            Debug.Assert(_entity.TryGetComponent(out _navMeshAgent),"NavMeshAgent component not found");

            IStatModule statModule = _entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null, "StatModule is not found");
            Debug.Assert(statModule.TryGetStat(Stats.MoveSpeed,out _speedStat),"Speed stat is not found");
            
            _speedStat.OnValueChanged += SpeedStatOnValueChanged;
            SetSpeed(_speedStat.Value);
        }

        private void OnDestroy()
        {
            _speedStat.OnValueChanged -= SpeedStatOnValueChanged;
        }

        private void SpeedStatOnValueChanged(float value, float oldValue)
        {
            SetSpeed(value);
        }
        private void SetSpeed(float speed)
        {
            if(_navMeshAgent != null)
                _navMeshAgent.speed = speed;
        }

        public void MoveToTarget(Vector3 target)
        {
            if(_navMeshAgent != null)
                _navMeshAgent.SetDestination(target);
        }

        public void MoveStop(bool stop)
        {
            if(_navMeshAgent != null)
                _navMeshAgent.isStopped = stop;
        }
        
        
    }
}