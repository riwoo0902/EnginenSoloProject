using _1.Script.EntityScript.ModuleSystem;
using _2.So._1.Scripts.AnimParam;
using UnityEngine;

namespace _1.Script.EntityScript.Entities.Modules.VisualSystem
{
    public class VisualModule : MonoBehaviour,IModule
    {
        [field:SerializeField] public Sprite EntityIcon { get; private set; }
        private Entity _entity;
        private Animator _animator;
        
        public void Initialize(ModuleOwner owner)
        {
            _entity = owner as Entity;
            _animator = GetComponent<Animator>();
            Debug.Assert(_animator != null, "animator is not found");
            
            
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