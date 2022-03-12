using System;
using UnityEngine.Events;

namespace GameOver
{
    public interface IGameOverEvents
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener">first param: current best score</param>
        public void OnNewBestScore(Action<int> listener);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener">first param: current score, second param: the best score</param>
        public void OnScore(Action<int, int> listener);
        

    }
}