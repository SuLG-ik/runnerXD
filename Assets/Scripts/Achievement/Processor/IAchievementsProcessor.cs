using System.Collections.Generic;
using UnityEngine.Events;

namespace Achievement.Processor
{
    public interface IAchievementsProcessor
    {
        public List<AchievementInfo> GetCurrentAchievements();
        public void NextAchievements();
        public void RegisterUpdateCurrentAchievementsListener(UnityAction<List<AchievementInfo>> listener);
        
        public void RegisterUpdateAchievementListener(UnityAction<AchievementInfo> listener);
        
    }
}