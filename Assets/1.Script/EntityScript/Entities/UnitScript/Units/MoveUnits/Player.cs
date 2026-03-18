using UnityEngine;
using UnityEngine.SceneManagement;

namespace _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits
{
    public class Player : MoveUnit
    {
        public static readonly Team PlayerTeam = Team.Blue;
        
        protected override void Awake()
        {
            myTeam = PlayerTeam;
            base.Awake();
            healthModule.OnDead += Dead;
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