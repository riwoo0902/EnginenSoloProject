using UnityEngine;

namespace _1.Script.Systems
{
    public static class AddClass
    {
        public static Vector3 ChangeToVector3(this Vector2 vec2)
        {
            return new Vector3(vec2.x, 0, vec2.y);
        }
        public static Vector2 ChangeToVector2(this Vector3 vec2)
        {
            return new Vector2(vec2.x,vec2.z);
        }
        
    }
}