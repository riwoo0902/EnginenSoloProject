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
        [SerializeField] private StatDataUI killStatUI;
        [SerializeField] private HealthDataUI entityHealthUI;
        [SerializeField] private EntityIconDataUI entityIconUI;

        [SerializeField] private StatDataUI attackDamageUI;
        [SerializeField] private StatDataUI attackSpeedUI;
        [SerializeField] private StatDataUI attackRangeUI;
        [SerializeField] private StatDataUI moveSpeedUI;
        public void On(Entity entity)
        {
            gameObject.SetActive(true);
            entityNameUI.SetText(entity.name);
            
            IStatModule statModule = entity.GetModule<IStatModule>();
            Debug.Assert(statModule != null,"statModule is not found");
            
            killStatUI.OnOff(statModule.TryGetStat(Stats.KillCount, out StatSO killCountStat));
            killStatUI.SetData(killCountStat);
            
            HealthModule healthModule = entity.GetModule<HealthModule>();
            entityHealthUI.OnOff(statModule.TryGetStat(Stats.MaxHp, out StatSO maxHpStat) && healthModule != null);
            entityHealthUI.SetData(healthModule,maxHpStat);
            
            VisualModule visualModule = entity.GetModule<VisualModule>();
            entityIconUI.OnOff(visualModule != null);
            entityIconUI.SetSprite(visualModule.EntityIcon);
            
            attackDamageUI.OnOff(statModule.TryGetStat(Stats.AttackDamage, out StatSO attackDamageStat));
            attackDamageUI.SetData(attackDamageStat);
            
            attackSpeedUI.OnOff(statModule.TryGetStat(Stats.AttackSpeed, out StatSO attackSpeedStat));
            attackSpeedUI.SetData(attackSpeedStat);
            
            attackRangeUI.OnOff(statModule.TryGetStat(Stats.AttackRange, out StatSO attackRangeStat));
            attackRangeUI.SetData(attackRangeStat);
            
            moveSpeedUI.OnOff(statModule.TryGetStat(Stats.MoveSpeed, out StatSO moveSpeedStat));
            moveSpeedUI.SetData(moveSpeedStat);
            
            
        }

        public void Off()
        {
            gameObject.SetActive(false);
        }
    }
}