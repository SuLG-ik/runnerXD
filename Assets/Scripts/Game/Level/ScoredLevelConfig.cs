using System;
using Game.Events;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Level
{
    public class ScoredLevelConfig : MonoBehaviour, ILevelConfig
    {
        [SerializeField] private int maxSpeed = 500;

        [SerializeField, Range(-100, 0)] private int initialMapSpeed = -5;
        [SerializeField, Range(-100, 0)] private int maxMapSpeed = -10;
        private float MapSpeedDelta => (float) maxSpeed / (initialMapSpeed - maxMapSpeed);
        
        [SerializeField] private int initialScoreDelta = 500;
        [SerializeField] private int maxScoreDelta = 50;
        private float ScoreDelta => (float) maxSpeed / (initialScoreDelta - maxScoreDelta);
        
        [SerializeField, Range(-100, 0)] private int initialStaticBarrierSpeed = -5;
        [SerializeField, Range(-100, 0)] private int maxStaticBarrierSpeed = -10;
        
        
        [SerializeField] private float initialCloudSpeed = -0.25f;
        [SerializeField] private float maxCloudSpeed = -1;
        private float CloudSpeedDelta => (float) maxSpeed / (initialCloudSpeed - maxCloudSpeed);
        
        
        private float StaticBarrierSpeed => (float) maxSpeed / (initialStaticBarrierSpeed - maxStaticBarrierSpeed);
        
        private IScoreboard _scoreboard;

        private void Start()
        {
            _scoreboard = FindObjectOfType<PlayerScoreboard>();
        }

        public int GetCurrentScoreDelta()
        {
            return Math.Max(maxScoreDelta, initialScoreDelta - (int) (_scoreboard.GetCurrentScore() / ScoreDelta));
        }

        public float GetCurrentCloudSpeed()
        {
            return Math.Max(maxMapSpeed, initialCloudSpeed - (_scoreboard.GetCurrentScore() / CloudSpeedDelta));
        }
        
        public int GetCurrentMapSpeed()
        {
            return Math.Max(maxMapSpeed, initialMapSpeed - (int) (_scoreboard.GetCurrentScore() / MapSpeedDelta));
        }

        public int GetCurrentStaticBarrierSpeed()
        {
            return Math.Max(maxStaticBarrierSpeed,
                initialStaticBarrierSpeed - (int) (_scoreboard.GetCurrentScore() / StaticBarrierSpeed));
        }

        public float GetBarrierSpawnDelta()
        {
            return (float) Math.Max(0.5, 1 - _scoreboard.GetCurrentScore() / maxSpeed / 2);
        }
    }
}