using System;
using Game.Level;
using UnityEngine;
using UnityEngine.UI;

namespace GameOver.GUI
{
    public class GameOverScoreGUI : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;

        [SerializeField] private Text currentScoreText;

        private void Start()
        {
            IGameOverEvents gameOverEvents = FindObjectOfType<ProgressGameOverEvents>();
            gameOverEvents.OnNewBestScore(OnDrawBestProgress);
            gameOverEvents.OnScore(OnDrawProgress);
        }

        private void OnDrawBestProgress(int currentProgress)
        {
            bestScoreText.text = "New the best score!!!";
            currentScoreText.text = $"{currentProgress}";
        }

        private void OnDrawProgress(int currentProgress, int bestProgress)
        {
            bestScoreText.text = $"Best score: {bestProgress}";
            currentScoreText.text = $"{currentProgress}";
        }
    }
}