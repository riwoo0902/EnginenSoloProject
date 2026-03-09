using _1.Script.EntityScript.Entities.FSM;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.Systems;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.UnitScript
{
    public class Unit : Entity
    {
        protected IStatModule statModule;
        
        protected override void Awake()
        {
            base.Awake();
            statModule = GetModule<IStatModule>();
            
            
        }




        
    }
}