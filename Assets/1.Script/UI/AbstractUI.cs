using _2.So._1.Scripts.DataBase;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1.Script.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class AbstractUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IIndexed
    {
        public int Index { get; set; }
      
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {  
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }
                
                return _rectTransform;
            }
        }

        public abstract void On();

        public abstract void Off();
        
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerClick(PointerEventData eventData);
    }
    
}