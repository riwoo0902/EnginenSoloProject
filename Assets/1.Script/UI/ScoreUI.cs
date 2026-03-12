using System;
using _1.Script.Systems;
using _1.Script.Systems.GameSystems.SaveSystem;
using _2.So._1.Scripts;
using _2.So._1.Scripts.EventChannels;
using GameLib.ObjectPool.Runtime;
using TMPro;
using UnityEngine;

namespace _1.Script.UI
{
    public class ScoreUI : MonoBehaviour,ISaveAble
    {
        [field:SerializeField] public SaveIdData SaveId { get; private set; }
        [SerializeField] private EventChannel entityChannel;
        private int _score  = 0;
        
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            entityChannel.AddListener<ScoreAddEvent>(AddScore);
        }

        private void AddScore(ScoreAddEvent obj)
        {
            _score += obj.addScore;
        }

        private void Update()
        {
            _text.text = $"Score : {_score}";
        }


        public string GetSaveData()
        {
            return _score.ToString();
        }

        public void RestoreData(string data)
        {
            if (int.TryParse(data,out int score))
            {
                _score = score;
            }
            else
            {
                _score = 0;
            }
        }
        
    }
}