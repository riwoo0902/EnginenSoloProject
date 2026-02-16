using UnityEngine;

namespace _2.So._1.Scripts.AnimParam
{
    [CreateAssetMenu(fileName = "Anim parameter", menuName = "Animator/Param")]
    public class AnimParamSO : ScriptableObject
    {
        [field: SerializeField] public string ParamName { get; private set; }
        [field: SerializeField] public int ParamHash { get; private set; }

        private void OnValidate()
        {
            ParamHash = Animator.StringToHash(ParamName);
        }
    }
}