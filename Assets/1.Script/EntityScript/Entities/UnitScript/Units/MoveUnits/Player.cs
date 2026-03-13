using UnityEngine;
using UnityEngine.SceneManagement;

namespace _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits
{
    public class Player : MoveUnit
    {
        public static Transform PlayerTrm;

        protected override void Awake()
        {
            base.Awake();
            PlayerTrm = transform;
            healthModule.OnDead += Dead;
        }

        private void Dead()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}