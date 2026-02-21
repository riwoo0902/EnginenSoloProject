using System;
using System.Collections.Generic;
using _10.InputSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace _1.Script.Systems.GameSystems
{
    public class MouseDragManager : MonoSingleton<MouseDragManager>
    {
        [SerializeField] private InputSO inputSo;
        [SerializeField] private EventChannel uiChannel;

        private static readonly DragData DragData = new DragData();
        public bool canDrag = true;
        protected override void Awake()
        {
            base.Awake();
            inputSo.OnMouseLeftPressed += DragStart;
            inputSo.OnMouseLeftReleased += DragEnd;
        }

        private void Update()
        {
            canDrag = !EventSystem.current.IsPointerOverGameObject();
            
            if (DragData.isDrag)
            {
                DragData.endPos = inputSo.mouseUIPosition;
                uiChannel.RaiseEvent(UIEvents.MouseDrag.Init(SettingAndSendDragData()));
            }
            
            
        }

        private void OnDestroy()
        {
            inputSo.OnMouseLeftPressed -= DragStart;
            inputSo.OnMouseLeftReleased -= DragEnd;
        }
        
        private void DragStart()
        {
            if (canDrag)
            {
                DragData.isDrag = true;
                DragData.startPos = inputSo.mouseUIPosition;
                uiChannel.RaiseEvent(UIEvents.MouseDrag.Init(SettingAndSendDragData()));
            }
            else
            {
                Debug.Log("UI Click");
            }
        } 
        
        private void DragEnd()
        {
            if (DragData.isDrag)
            {
                DragData.isDrag = false;
                DragData.endPos = inputSo.mouseUIPosition;
                uiChannel.RaiseEvent(UIEvents.MouseDrag.Init(SettingAndSendDragData()));
                uiChannel.RaiseEvent(UIEvents.MouseDragEnd.Init(DragData.minVec,DragData.maxVec));
            }
            
        }

        private DragData SettingAndSendDragData()
        {
            (DragData.minVec.x,DragData.maxVec.x) = (DragData.startPos.x < DragData.endPos.x) ? 
                (DragData.startPos.x, DragData.endPos.x) : (DragData.endPos.x, DragData.startPos.x);
            (DragData.minVec.y,DragData.maxVec.y) = (DragData.startPos.y < DragData.endPos.y) ? 
                (DragData.startPos.y, DragData.endPos.y) : (DragData.endPos.y, DragData.startPos.y);
            return DragData;
        }
        
    }
    
    public class DragData
    {
        public bool isDrag = false;
        public Vector2 startPos;
        public Vector2 endPos;
        public Vector2 minVec;
        public Vector2 maxVec;
    }
    
}