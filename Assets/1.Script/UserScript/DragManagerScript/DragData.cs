using UnityEngine;

namespace _1.Script.UserScript.DragManagerScript
{
    public class DragData
    {
        public DragData(Vector2 position, Vector2 size)
        {
            pos =  position;
            this.size = size;
        }
        public Vector2 pos;
        public Vector2 size;
    }
}