using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI
{
    public abstract class AbstractUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}