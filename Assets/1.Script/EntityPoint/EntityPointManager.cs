using System.Collections.Generic;
using System.Linq;
using _1.Script.EntityScript;
using UnityEngine;

namespace _1.Script.EntityPoint
{
    public class EntityPointManager : MonoBehaviour
    {
        [SerializeField] private GameObject entityPointPrefab;
        private readonly Dictionary<Entity,EntityPoint> _entityPoints = new();

        public EntityPointManager Instance { get; private set; }
        private void Awake()
        {
            #region Instance
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion
        }

        public void AddEntityPoint(Entity entity)
        {
            EntityPoint point = GetEntityPoint();
            point.SetTarget(entity.transform);
            _entityPoints.Add(entity, point);
        }


        private EntityPoint GetEntityPoint()
        {
            EntityPoint entityPoint = _entityPoints.Values.FirstOrDefault(entityPoint => !entityPoint.IsHaveTarget);

            if (entityPoint == null)
            {
                entityPoint = Instantiate(entityPointPrefab,transform).GetComponent<EntityPoint>();
            }

            return entityPoint;
        }
        
        
        
        
        
    }
}