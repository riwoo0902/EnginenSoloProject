using UnityEngine;

namespace _1.Script.EventBusScript.Events
{
    public class Drag : IEvent
    {
        public Drag(Vector2 position, Vector2 size)
        {
            pos =  position;
            this.size = size;
        }
        public Vector2 pos;
        public Vector2 size;
    }
}