using UnityEngine;

namespace _1.Script.EntityScript.Entities
{
    public class EntityData
    {
        public Sprite entitySprite;
        public Team team = Team.Yellow;
        public int maxHp;
        public int currentHp;
        public int damage;

        public EntityData()
        {
            
        }
    }
}