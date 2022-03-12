namespace Achievement
{
    public class AchievementInfo
    {
        public bool IsActive;

        public string Title;

        public string HandlerId;

        public AchievementProgress Progress;

        public AchievementInfo(string title, string handlerId, AchievementProgress achievementProgress, bool isActive = false)
        {
            Title = title;
            HandlerId = handlerId;
            Progress = achievementProgress;
            IsActive = isActive;
        }

        public class AchievementProgress
        {

            public int Current;
            public int Target;

            public bool IsCompleted => Current >= Target;

            public AchievementProgress(int current, int target)
            {
                Current = current;
                Target = target;
            }
        }
        
    }
}