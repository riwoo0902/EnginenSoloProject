using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript.Entities;
using _1.Script.Systems;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.EntityScript.EntityPointScript
{
    public class EntityPointManager : MonoSingleton<EntityPointManager>
    {
        [SerializeField] private EventChannel entityChannel;
        [SerializeField] private GameObject entityPointPrefab;
        private readonly Dictionary<Entity,EntityPoint> _entityPoints = new();
        private List<EntityPoint> entityPoints = new();
        protected override void Awake()
        {
            base.Awake();
            entityChannel.AddListener<EntitySpawnEvent>(AddEntityPoint);
            entityChannel.AddListener<EntityDestroyEvent>(RemoveEntityPoint);
        }
        public void AddEntityPoint(EntitySpawnEvent entity)
        {
            EntityPoint point = GetEntityPoint();
            point.SetTarget(entity.entity);
            _entityPoints.Add(entity.entity, point);
            entityPoints.Add(point);
        }

        public void RemoveEntityPoint(EntityDestroyEvent entity)
        {
            if (_entityPoints.TryGetValue(entity.entity, out EntityPoint point))
            {
                point.RemoveTarget();
                _entityPoints.Remove(entity.entity);
            }
        }

        private EntityPoint GetEntityPoint()
        {
            EntityPoint entityPoint = entityPoints.FirstOrDefault(entityPoint => !entityPoint.IsHaveTarget);

            if (entityPoint == null)
            {
                GameObject entityPointObject = Instantiate(entityPointPrefab,transform);
                if (entityPointObject.TryGetComponent(out EntityPoint point))
                {
                    entityPoint = point;
                }
                else
                {
                    entityPoint = entityPointObject.AddComponent<EntityPoint>();
                    Debug.LogError("entityPointPrefab is not have EntityPoint");
                }
            }
            entityPoint.gameObject.SetActive(true);
            return entityPoint;
        }

        private void OnDestroy()
        {
            entityChannel.RemoveListener<EntitySpawnEvent>(AddEntityPoint);
            entityChannel.RemoveListener<EntityDestroyEvent>(RemoveEntityPoint);
        }
    }
}