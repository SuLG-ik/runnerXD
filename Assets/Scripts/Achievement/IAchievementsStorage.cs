using System.Collections.Generic;

namespace Achievement
{
    public interface IAchievementsStorage
    {
        public void SaveNewAchievements(List<AchievementInfo> achievements);

        public List<string> FetchSavedHandlersId();

    }
}