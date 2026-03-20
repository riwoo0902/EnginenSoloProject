using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills
{
    public class SpawnerCreateSkill : AbstractSkill
    {
        [SerializeField] private GameObject spawnerPrefab;
        
        public override void UseSkill()
        {
            GameObject spawner = Instantiate(spawnerPrefab);
            Vector3 position = entity.transform.position;
            position.y = 3;
            spawner.transform.position = position;
        }
        
        
    }
}