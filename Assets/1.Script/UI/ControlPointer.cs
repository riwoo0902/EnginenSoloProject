using _1.Script.Systems;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI
{
    public class ControlPointer : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private new ParticleSystem particleSystem;
        
        private const float YPos = 1;
        private void Awake()
        {
            uiChannel.AddListener<SetPointerEvent>(SetPointer);
            uiChannel.AddListener<EntitySelectionEvent>(HidePointer);
            
            gameObject.SetActive(false);
        }

        private void HidePointer(EntitySelectionEvent obj)
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<SetPointerEvent>(SetPointer);
            uiChannel.RemoveListener<EntitySelectionEvent>(HidePointer);
        }
        
        private void SetPointer(SetPointerEvent obj)
        {
            gameObject.SetActive(true);
            particleSystem.Play();
            Vector3 vec = obj.pointerPos.ChangeToVector3();
            vec.y = YPos;
            transform.position = vec;
        }
        
    }
}