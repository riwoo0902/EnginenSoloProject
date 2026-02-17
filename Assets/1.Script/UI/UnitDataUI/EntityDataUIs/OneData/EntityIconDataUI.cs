using UnityEngine;

namespace _1.Script.UI.UnitDataUI.EntityDataUIs.OneData
{
    public class EntityIconDataUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string value)
        {
            _textMesh.text = value;
        }

        public void OnOff(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}