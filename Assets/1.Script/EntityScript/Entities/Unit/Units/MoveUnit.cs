using _1.Script.EntityScript.Entities.Modules.MoveSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _1.Script.EntityScript.Entities.Unit.Units
{
    public class MoveUnit : Unit
    {
        protected IMoveModule moveModule;

        protected override void Awake()
        {
            base.Awake();
            moveModule = GetModule<IMoveModule>();
        }

        protected override void Update()
        {
            base.Update();
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                if(moveModule != null) moveModule.MoveToTarget(transform.position + new Vector3(10,0,0));   
            }
        }
        
        
        
    }
}