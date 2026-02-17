using _1.Script.EntityScript.Entities;
using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using _1.Script.EntityScript.Entities.Modules.StatSystem;
using _1.Script.EntityScript.Entities.Modules.VisualSystem;
using _1.Script.UI.UnitDataUI.EntityDataUIs.OneData;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs
{
    public class OneEntityDataManager : MonoBehaviour
    {
        [SerializeField] private EntityNameDataUI entityNameUI;
        [SerializeField] private KillCountDataUI entityKillCountUI;
        [SerializeField] private HealthDataUI entityHealthUI;
        [SerializeField] private EntityIconDataUI entityIconUI;
        public void On(Entity entity)
        {
            gameObject.SetActive(true);
            entityNameUI.SetText(entity.name);
            
            IStatModule statModule = entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null,"statModule is not found");
            
            entityKillCountUI.OnOff(statModule.TryGetStat(Stats.KillCount, out StatSO killCountStat));
            entityKillCountUI.SetData(killCountStat);
            
            HealthModule healthModule = entity.GetModule<HealthModule>();
            entityHealthUI.OnOff(statModule.TryGetStat(Stats.MaxHp, out StatSO maxHpStat) && healthModule != null);
            entityHealthUI.SetData(healthModule,maxHpStat);
            
            VisualModule visualModule = entity.GetModule<VisualModule>();
            entityIconUI.OnOff(visualModule != null);
            entityIconUI.SetSprite(visualModule.EntityIcon);
            
            
            
            Debug.Log("OneDataShow");
        }

        public void Off()
        {
            gameObject.SetActive(false);
        }
    }
}