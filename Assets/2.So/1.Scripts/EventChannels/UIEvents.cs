using _1.Script.Systems.GameSystems;
using UnityEngine;

namespace _2.So._1.Scripts.EventChannels
{
    public static class UIEvents
    {
        public static readonly MouseDragEvent MouseDrag =  new MouseDragEvent();
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
    
}