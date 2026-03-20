using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.FSM;
using UnityEngine;

namespace _2.So._1.Scripts.EventChannels
{
    public static class EntityEvents
    {
        public static readonly EntitySpawnEvent EntitySpawn = new EntitySpawnEvent();
        public static readonly EntityDestroyEvent EntityDestroy = new EntityDestroyEvent();
        public static readonly ScoreAddEvent ScoreAdd = new ScoreAddEvent();
        public static readonly PlayerMoveEvent PlayerMove = new PlayerMoveEvent();
        public static readonly GameEndEvent GameEnd = new GameEndEvent();
    }

    public class EntitySpawnEvent : GameEvent
    {
        public Entity entity;
        
        public EntitySpawnEvent Init(Entity data)
        {
            entity = data;
            return this;
        }
    }
    public class EntityDestroyEvent : GameEvent
    {
        public Entity entity;
        
        public EntityDestroyEvent Init(Entity data)
        {
            entity = data;
            return this;
        }
    }
    public class ScoreAddEvent : GameEvent
    {
        public int addScore;
        
        public ScoreAddEvent Init(int data)
        {
            addScore = data;
            return this;
        }
    }

    public class PlayerMoveEvent : GameEvent
    {
        public Vector3 playerPos;
        
        public PlayerMoveEvent Init(Vector3 pos)
        {
            playerPos = pos;
            return this;
        }
    }
    public class GameEndEvent : GameEvent 
    {
        public int value;
        public GameEndEvent Init(int data)
        {
            value = data;
            return this;
        }
        
    }
}