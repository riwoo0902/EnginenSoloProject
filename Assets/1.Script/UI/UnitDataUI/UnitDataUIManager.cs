using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using UnityEngine;

namespace _1.Script.UI.UnitDataUI
{
    public class UnitDataUIManager : MonoBehaviour
    {
        [SerializeField] private EventChannel uiChannel;
        [SerializeField] private ShowType showType;
        
        
        private void Awake()
        {
            uiChannel.AddListener<EntitySelectionEvent>(ShowEntityData);
        }

        private void OnDestroy()
        {
            uiChannel.RemoveListener<EntitySelectionEvent>(ShowEntityData);
        }

        private void ShowEntityData(EntitySelectionEvent evt)
        {
            if (evt.entities.Count == 0)
            {
                showType = ShowType.Null;
            }
            else if (evt.entities.Count == 1)
            {
                showType = ShowType.One;
            }
            else
            {
                showType = ShowType.Multiple;
            }
            Debug.Log(showType.ToString());
            
        }

        private enum ShowType
        {
            One,Multiple,Null
        }
    }
}