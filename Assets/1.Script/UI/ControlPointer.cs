using System;
using _1.Script.EntityScript.Entities.FSM;
using _1.Script.Systems;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI
{
    public class ControlPointer : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private EventChannel soundChannel;
        [SerializeField] private SoundClipSO clipSo;
        [SerializeField] private new ParticleSystem particleSystem;
        [SerializeField] private ControlPointerRenderer controlPointerRenderer;
        private Transform _cameraTransform;
        private const float YPos = 1;
        private void Awake()
        {
            uiChannel.AddListener<SetPointerEvent>(SetPointer);
            uiChannel.AddListener<EntitySelectionEvent>(HidePointer);
            _cameraTransform = Camera.main.transform;
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
        
        private void SetPointer(SetPointerEvent evt)
        {
            soundChannel.RaiseEvent(SoundEvents.PlaySoundEvent.Init(_cameraTransform.position,clipSo));
            gameObject.SetActive(true);
            particleSystem.Play();
            Vector3 vec = evt.pointerPos.ChangeToVector3();
            vec.y = YPos;
            transform.position = vec;

            if (evt.controlType == StateType.AttackMove)
            {
                particleSystem.startColor = Color.red;
                controlPointerRenderer.SetColor(Color.red);
            }
            else if (evt.controlType == StateType.Move)
            {
                particleSystem.startColor = Color.green;
                controlPointerRenderer.SetColor(Color.green);
            }
            
        }
        
    }
}