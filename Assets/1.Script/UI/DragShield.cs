using _1.Script.Systems.GameSystems;
using _10.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI
{
    public class DragShield : MonoBehaviour,IPointerDownHandler,IPointerExitHandler,IPointerUpHandler,IPointerMoveHandler,IPointerEnterHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {
            MouseDragManager.Instance.canDrag = false;
            Debug.Log("DragFalse");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MouseDragManager.Instance.canDrag = true;
            Debug.Log("DragTure");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("PointerUp");
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            Debug.Log("PointerMove");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("PointerEnter");
        }
    }
}