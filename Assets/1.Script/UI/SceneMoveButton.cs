using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1.Script.UI
{
    [RequireComponent(typeof(Button))]
    public class SceneMoveButton : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ButtonClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ButtonClicked);
        }

        public void ButtonClicked()
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}