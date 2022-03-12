using System;
using Game.Level;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace GameOver
{
    public class ProgressGameOverEvents: MonoBehaviour,  IGameOverEvents
    {

        private int currentProgress = -1;
        private int bestProgress = -1;

        [Inject]
        private IProgressSaver progressSaver;
        
        private void CacheProgress()
        {
            if (currentProgress < 0 || bestProgress < 0)
            {
                currentProgress = progressSaver.GetLastProgress();
                bestProgress = progressSaver.GetBestProgress();
            }
        }
        
        public void OnNewBestScore(Action<int> listener)
        {
            CacheProgress();
            if (currentProgress == bestProgress)
                listener?.Invoke(currentProgress);
        }

        public void OnScore(Action<int, int> listener)
        {
            CacheProgress();
            if (currentProgress != bestProgress)
                listener?.Invoke(currentProgress, bestProgress);
        }
    }
}