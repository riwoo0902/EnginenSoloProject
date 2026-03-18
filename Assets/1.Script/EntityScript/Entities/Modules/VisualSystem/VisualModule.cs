using _1.Script.EntityScript.Entities.UnitScript.Units.MoveUnits;
using _1.Script.EntityScript.ModuleSystem;
using _2.So._1.Scripts.AnimParam;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.VisualSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class VisualModule : MonoBehaviour,IModule
    {
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        [field:SerializeField] public Sprite EntityIcon { get; private set; }
        private Entity _entity;
        private Animator _animator;
        private Material _material;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            _animator = GetComponent<Animator>();
            Debug.Assert(_animator != null, "animator is not found");

            MeshRenderer meshRender = GetComponent<MeshRenderer>();
            _material = new Material(meshRender.material);
            meshRender.material = _material;
            Debug.Assert(_material != null, "Material is not found");
        }

        private void Start()
        {
            if(_entity is Player) SetColor(Color.yellow);
            else if(_entity.myTeam == Team.Blue) SetColor(Color.blue);
            else if(_entity.myTeam == Team.Red) SetColor(Color.red);
        }

        private void SetColor(Color color)
        {
            _material.SetColor(Color1, color);
        }
        
        public void PlayClip(int clipHash, int layer = -1, float normalizedTime = 0)
            => _animator.Play(clipHash, layer, normalizedTime);
        
        public void SetBool(AnimParamSO param, bool value)
            => _animator.SetBool(param.ParamHash, value);
        public void SetFloat(AnimParamSO param, float value)
            => _animator.SetFloat(param.ParamHash, value);
        public void SetInt(AnimParamSO param, int value)
            => _animator.SetInteger(param.ParamHash, value);
        public void SetTrigger(AnimParamSO param)
            => _animator.SetTrigger(param.ParamHash);
        
        
    }
}