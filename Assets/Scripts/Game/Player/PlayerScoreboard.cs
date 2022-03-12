using Game.Events;
using Game.Level;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Player
{
    public class PlayerScoreboard : MonoBehaviour, IScoreboard
    {
        private event UnityAction<int> Listeners;

        private int _currentScore;

        private int _lastScoreTime;

        private bool _isResume = true;

        private ILevelConfig _levelConfig;
        
        private void Start()
        {
            _levelConfig = FindObjectOfType<ScoredLevelConfig>();
            Reset();
        }

        private void Update()
        {
            OnTick();
        }

        private int GetCurrentTimeMillis()
        {
            return (int) (Time.time * 1000);
        }

        private void OnTick()
        {
            var deltaTime = GetCurrentTimeMillis() - _lastScoreTime;
            var deltaScore = _levelConfig.GetCurrentScoreDelta();
            if (deltaTime > deltaScore && _isResume)
            {
                OnListeners(_currentScore += deltaTime / deltaScore);
                _lastScoreTime = GetCurrentTimeMillis();
            }
        }

        private void OnListeners(int arg0)
        {
            Listeners?.Invoke(arg0);
        }

        public void Reset()
        {
            _lastScoreTime = GetCurrentTimeMillis();
            _currentScore = 0;
        }

        public int GetCurrentScore()
        {
            return _currentScore;
        }

        public void RegisterUpdateScoreListener(UnityAction<int> listener)
        {
            Listeners += listener;
        }

        public void Pause()
        {
            _isResume = false;
        }

        public void Resume()
        {
            _isResume = true;
        }
    }
}