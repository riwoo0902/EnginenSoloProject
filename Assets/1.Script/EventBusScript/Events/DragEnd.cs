using UnityEngine;

namespace _1.Script.EventBusScript.Events
{
    public class DragEnd : IEvent
    {
        public DragEnd(Vector2 startPos, Vector2 endPos)
        {
            dragStartPos =  startPos;
            dragEndPos = endPos;
        }
        public Vector2 dragStartPos;
        public Vector2 dragEndPos;
        
    }
    
}