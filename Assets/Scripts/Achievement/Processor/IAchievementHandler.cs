namespace Achievement.Processor
{
    public interface IAchievementHandler
    {
        /// <summary>
        /// Invalidate previous achievement completed state. Starts before Initialize()
        /// </summary>
        public void Invalidate();

        
        /// <summary>
        /// Starts when achievement are not completed, must be invalidated before in Invalidate() if necessary. Register any listeners
        /// </summary>
        public void Initialize();

        
        /// <summary>
        /// Starts when achievement are completed. Unregister any listeners
        /// </summary>
        public void Destroy();

        /// <summary>
        /// Info must be available any time even when handler does not initialized or invalidated. 
        /// </summary>
        /// <returns>Loaded info</returns>
        public AchievementInfo GetInfo();

    }
}