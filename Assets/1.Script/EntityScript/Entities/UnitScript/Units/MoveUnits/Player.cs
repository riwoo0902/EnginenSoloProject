using _2.So._1.Scripts.EventChannels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits
{
    public class Player : MoveUnit
    {
        public static readonly Team PlayerTeam = Team.Blue;
        
        private float _lastTime = 0;
        private const float Delay = 0.5f;
        
        protected override void Awake()
        {
            myTeam = PlayerTeam;
            base.Awake();
            healthModule.OnDead += Dead;
        }
        
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (Time.time - _lastTime > Delay)
            {
                _lastTime = Time.time;
                entityChannel.RaiseEvent(EntityEvents.PlayerMove.Init(transform.position));
            }
            
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            healthModule.OnDead -= Dead;
        }

        private void Dead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}