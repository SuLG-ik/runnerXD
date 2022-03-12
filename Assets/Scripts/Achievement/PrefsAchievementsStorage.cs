using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Game;
using UnityEngine;
using UnityEngine.Events;

namespace Achievement
{
    public class PrefsAchievementsStorage : MonoBehaviour, IAchievementsStorage
    {
        public void SaveNewAchievements(List<AchievementInfo> achievements)
        {
            if (achievements.Count != 3) throw new ArgumentException();
            for (var i = 0; i < achievements.Count; i++)
            {
                SaveNewAchievement(achievements[i], i);
            }
            PlayerPrefs.Save();
        }

        private string SaveNewAchievement(AchievementInfo achievementInfo, int index)
        {
            PlayerPrefs.SetString($"achievement_{index}", achievementInfo.HandlerId);
            return achievementInfo.HandlerId;
        }

        public List<string> FetchSavedHandlersId()
        {
            var saved = new List<string>() {FetchSavedHandlerId(0), FetchSavedHandlerId(1), FetchSavedHandlerId(2)};
            return saved.All(id => id != null) ? saved : null;
        }

        private string FetchSavedHandlerId(int index)
        {
            var handlerId = PlayerPrefs.GetString($"achievement_{index}", "-");
            return handlerId == "-" ? null : handlerId;
        }
    }
}