namespace Game.Level
{
    public interface IProgressSaver
    {

        /// <summary>
        /// Save progress and update the best if it higher then previous
        /// </summary>
        /// <returns></returns>
        public void SaveProgress(int progress);

        
        /// <summary>
        /// </summary>
        /// <returns>Previous score (-1 if does not exists)</returns>
        public int GetLastProgress();

        /// <summary>
        /// </summary>
        /// <returns>The best score (-1 if does not exists)</returns>
        public int GetBestProgress();

    }
}