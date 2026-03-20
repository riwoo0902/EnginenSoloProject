using System;
using System.Collections.Generic;
using _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem;
using _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills;
using _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;
using UnityEngine.UI;

namespace _1.Script.UI.ControlUI
{
    [RequireComponent(typeof(Button))]
    public class SkillControlButton : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        private readonly List<SpawnerCreateSkill> _skillModules = new List<SpawnerCreateSkill>(200);

        private void Awake()
        {
            uiChannel.AddListener<EntitySelectionEvent>(CheckSkillModuleOwner);
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<EntitySelectionEvent>(CheckSkillModuleOwner);
        }

        private void CheckSkillModuleOwner(EntitySelectionEvent obj)
        {
            _skillModules.Clear();
            foreach (var entity in obj.entities)
            {
                if(!(entity is MagicUnit ||  entity is Player)) continue;
                
                if (entity.TryGetModule(out ISkillModule skillModule))
                {
                    if (skillModule.TryGetSkill(out SpawnerCreateSkill skill))
                    {
                        _skillModules.Add(skill);
                    }
                    
                }
            }

            gameObject.SetActive(_skillModules.Count > 0);
        }

        public void UseSkill()
        {
            _skillModules.ForEach(skill => skill.UseSkill());
        }
        
    }
}