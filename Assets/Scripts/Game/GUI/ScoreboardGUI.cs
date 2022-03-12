using System;
using Game.Events;
using Game.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.GUI
{
    public class ScoreboardGUI : MonoBehaviour
    {

        [SerializeField]
        private Text scoreText;

        private void Start()
        {
            var scoreboard = FindObjectOfType<PlayerScoreboard>();
            UpdateScore(scoreboard.GetCurrentScore());
            scoreboard.RegisterUpdateScoreListener(UpdateScore);
        }

        private void UpdateScore(int score)
        {
            scoreText.text = $"Очки: {score}";
        }

    }
}