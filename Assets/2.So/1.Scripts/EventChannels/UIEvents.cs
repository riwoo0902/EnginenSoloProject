using _1.Script.Systems.GameSystems;
using UnityEngine;

namespace _2.So._1.Scripts.EventChannels
{
    public static class UIEvents
    {
        public static readonly MouseDragEvent MouseDrag =  new MouseDragEvent();
        public static readonly MouseDragEndEvent MouseDragEnd =  new MouseDragEndEvent();

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
    
}