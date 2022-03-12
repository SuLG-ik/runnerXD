using System;
using System.Collections.Generic;

namespace Achievement.Processor
{
    public interface IAchievementsCatalog
    {
        public List<IAchievementHandler> GetAchievementHandlers(Action<IAchievementHandler> onComplete,
            Action<IAchievementHandler> onUpdate);
    }
}