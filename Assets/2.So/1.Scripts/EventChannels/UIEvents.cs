using System.Collections.Generic;
using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.FSM;
using _1.Script.Systems.GameSystems;
using UnityEngine;

namespace _2.So._1.Scripts.EventChannels
{
    public static class UIEvents
    {
        public static readonly MouseDragEvent MouseDrag =  new MouseDragEvent();
        public static readonly MouseDragEndEvent MouseDragEnd =  new MouseDragEndEvent();
        public static readonly EntitySelectionEvent EntitySelection =  new EntitySelectionEvent();
        public static readonly CameraMoveEvent CameraMove =  new CameraMoveEvent();
        public static readonly SetPointerEvent SetPointer =  new SetPointerEvent();
        public static readonly ChangeEntityControlEvent ChangeEntityControl = new ChangeEntityControlEvent();
    }

    public class MouseDragEvent : GameEvent
    {
        public DragData dragData;
        
        public MouseDragEvent Init(DragData data)
        {
            dragData = data;
            return this;
        }
    }
    
    public class MouseDragEndEvent : GameEvent
    {
        public Vector2 startPos;
        public Vector2 endPos;
        
        public MouseDragEndEvent Init(Vector2 data1,Vector2 data2)
        {
            startPos =  data1;
            endPos = data2;
            return this;
        }
    }
    
    public class EntitySelectionEvent : GameEvent
    {
        public List<Entity> entities;
        
        public EntitySelectionEvent Init(List<Entity> data)
        {
            entities = data;
            return this;
        }
    }
    
    public class CameraMoveEvent : GameEvent
    {
        public Vector2 moveVector;
        
        public CameraMoveEvent Init(Vector2 moveVec)
        {
            moveVector = moveVec;
            return this;
        }
    }

    public class SetPointerEvent : GameEvent
    {
        public Vector2 pointerPos;
        public StateType controlType;
        public SetPointerEvent Init(Vector2 pos,StateType type)
        {
            pointerPos = pos;
            controlType = type;
            return this;
        }
    }
    public class ChangeEntityControlEvent : GameEvent
    {
        public StateType controlType;
        public ChangeEntityControlEvent Init(StateType type)
        {
            controlType = type;
            return this;
        }
    }
}