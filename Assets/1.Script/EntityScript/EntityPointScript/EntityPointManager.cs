using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.Entities;
using _1.Script.Systems;
using _1.Script.Systems.EventBusScript;
using _1.Script.Systems.EventBusScript.Events;
using UnityEngine;

namespace _1.Script.EntityScript.EntityPointScript
{
    public class EntityPointManager : MonoSingleton<EntityPointManager>
    {
        [SerializeField] private GameObject entityPointPrefab;
        private readonly Dictionary<Entity,EntityPoint> _entityPoints = new();

        protected override void Awake()
        {
            base.Awake();
            EventBus<EntitySpawn>.OnEvent += AddEntityPoint;
        }
        public void AddEntityPoint(EntitySpawn entity)
        {
            EntityPoint point = GetEntityPoint();
            point.SetTarget(entity.entity.transform);
            _entityPoints.Add(entity.entity, point);
        }

        private EntityPoint GetEntityPoint()
        {
            EntityPoint entityPoint = _entityPoints.Values.FirstOrDefault(entityPoint => !entityPoint.IsHaveTarget);

            if (entityPoint == null)
            {
                GameObject entityPointObject = Instantiate(entityPointPrefab,transform);
                entityPoint = entityPointObject.TryGetComponent(out EntityPoint point) ? 
                    point : 
                    entityPointObject.AddComponent<EntityPoint>();
            }

            return entityPoint;
        }

        private void OnDestroy()
        {
            EventBus<EntitySpawn>.OnEvent -= AddEntityPoint;
        }
    }
}