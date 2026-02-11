using System;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace _1.Script.UI
{
    public class DragUI : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private Image image;

        private void Awake()
        {
            uiChannel.AddListener<MouseDragEvent>(MouseDragUI);
        }

        private void MouseDragUI(MouseDragEvent evt)
        {
            if (evt.dragData.isDrag)
            {
                image.gameObject.SetActive(true);
                
                Vector2 center = evt.dragData.maxVec - evt.dragData.minVec;

                image.rectTransform.anchoredPosition = evt.dragData.minVec + center / 2;
                image.rectTransform.sizeDelta = center;
                
                
            }
            else
            {
                image.gameObject.SetActive(false);
            }
            
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<MouseDragEvent>(MouseDragUI);
        }
    }
}