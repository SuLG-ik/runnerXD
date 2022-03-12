using UnityEngine.Events;
using Utils;

namespace Game.Events
{
    public interface IScoreboard : IResettable
    {
        public void Pause();

        public void Resume();

        public int GetCurrentScore();

        public void RegisterUpdateScoreListener(UnityAction<int> listener);
    }
}