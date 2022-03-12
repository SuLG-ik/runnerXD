using System;
using UnityEngine;

namespace Game.Level
{
    public class PreferencesProgressSaver: IProgressSaver
    {
        public void SaveProgress(int progress)
        {
            PlayerPrefs.SetInt(LastProgressKey, progress);
            var bestProgress = GetBestProgress();
            if (progress > bestProgress)
                PlayerPrefs.SetInt(BestProgressKey, progress);
            PlayerPrefs.Save();
        }

        public int GetLastProgress()
        {
            return PlayerPrefs.GetInt(LastProgressKey, -1);
        }

        public int GetBestProgress()
        {
            return PlayerPrefs.GetInt(BestProgressKey, -1);
        }

        private const string BestProgressKey = "best_progress";
        private const string LastProgressKey = "last_progress";
    }
}