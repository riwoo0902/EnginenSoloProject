using System.Collections.Generic;
using _1.Script.CollisionManagerScript;
using _1.Script.EntityScript;
using _1.Script.EventBusScript;
using _1.Script.EventBusScript.Events;
using Unity.Mathematics;
using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class EntitySelectManager : MonoBehaviour
    {
        public List<Entity> entities = new();
        
        private void Awake()
        {
            _camera = Camera.main;
            EventBus<DragEnd>.OnEvent += DragEnd;
        }
        
        private Camera _camera;
        
        private void DragEnd(DragEnd dragEnd)
        {
            entities.Clear();
            
            Vector2 size = (dragEnd.dragEndPos - dragEnd.dragStartPos);

            Vector2 rectstartPos = dragEnd.dragStartPos;

            if (size.x < 0)
            {
                rectstartPos.x = dragEnd.dragEndPos.x;
            }

            if (size.y < 0)
            {
                rectstartPos.y = dragEnd.dragEndPos.y;
            }
            
            Rect dragRect = new Rect(rectstartPos, math.abs(size));
            
            foreach (Entity e in CollisionManage<Entity>.Values)
            {
                Vector2 a = _camera.WorldToScreenPoint(e.transform.position);
                if (dragRect.Contains(a))
                {
                    entities.Add(e);
                }
            }
            
        }

        private void OnDestroy()
        {
            EventBus<DragEnd>.OnEvent -= DragEnd;
        }
        
        
    }
}