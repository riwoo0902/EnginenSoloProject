using _1.Script.EntityScript.Entities.Modules.HealthSystem;
using GameLib.ObjectPool.Runtime;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.AttackSystem.SkillSystem.Skills.NormalAttackSkillScript
{
    [RequireComponent(typeof(Collider),typeof(MeshRenderer))]
    public class TargetBullet : MonoBehaviour,IPoolable
    {
        [SerializeField] private PoolManagerSO poolManagerSo;
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        private Transform _self;
        private Transform _target;
        private float _damage;
        private float _speed;
        private Material _material;
        private Team _myTeam;
        private bool _isattacking = false;
        private void Awake()
        {
            _self = transform;
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            _material = new Material(meshRenderer.material);
            meshRenderer.material = _material;
        }
        private void Start()
        {
            if(_myTeam == Team.Blue) SetColor(Color.blue);
            else if(_myTeam == Team.Red) SetColor(Color.red);
        }

        private void SetColor(Color color)
        {
            _material.SetColor(Color1, color);
        }

        public void SetData(Team team,Transform  target, float damage,float speed)
        {
            _myTeam = team;
            _target = target;
            _damage = damage;
            _speed = speed;
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 direction = (_target.position - _self.position).normalized;
                _self.position += direction * (_speed * Time.fixedDeltaTime);
            }
            else
            {
                PoolInitializer.Instance.Push(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == _target)
            {
                if (_target.TryGetComponent(out Entity entity))
                {
                    if (entity.TryGetModule(out HealthModule healthModule))
                    {
                        healthModule.Hp -= _damage;
                        PoolInitializer.Instance.Push(this);
                    }
                }
            }
        }

        
        [field:SerializeField] public PoolItemSO PoolItem { get; set; }
        public GameObject GameObject => gameObject;
        public void ResetItem()
        {
            _target = null;
        }
        
        
    }
}