using System;
using _1.Script.Systems;
using TMPro;
using UnityEngine;

namespace _1.Script.UI
{
    public class EndTextUI : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            text.text = GameDataManager.GameData == 0 ? "Win!" : "Lose!" ;
        }
    }
}