using System;
using Achievement.Events;
using Achievement.EventsBus;
using Achievement.Processor;
using Game;
using UnityEngine;
using UnityEngine.Events;
using World.Barriers;
using Zenject;

namespace Achievement.Handlers
{
    public class CollisionAchievementHandler : IAchievementHandler
    {
        private readonly int _collisionCount;

        private readonly BarrierType _type;

        private readonly Action<IAchievementHandler> _onComplete;

        private readonly Action<IAchievementHandler> _onUpdate;

        private int progress = -1;

        private bool _isActive = false;

        public CollisionAchievementHandler(int collisionCount, BarrierType type, Action<IAchievementHandler> onComplete,
            Action<IAchievementHandler> onUpdate)
        {
            _collisionCount = collisionCount;
            _type = type;
            _onComplete = onComplete;
            _onUpdate = onUpdate;
        }


        private void OnCollision(CollisionEvent collision)
        {
            if (collision.Type == _type)
            {
                var progress = GetCurrentProgress();
                UpdateCurrentProgress(++progress);
                _onUpdate(this);
                if (progress >= _collisionCount)
                {
                    _onComplete(this);
                }
            }
        }

        private int GetCurrentProgress()
        {
            return progress == -1 ? progress = PlayerPrefs.GetInt(GetId(), 0) : progress;
        }

        private void UpdateCurrentProgress(int progress)
        {
            this.progress = progress;
        }

        private void SaveAll()
        {
            PlayerPrefs.SetInt(GetId(), GetCurrentProgress());
            PlayerPrefs.Save();
        }

        private string GetId()
        {
            return $"collisionhandler_{_type}_{_collisionCount}";
        }


        public void Invalidate()
        {
            progress = 0;
            SaveAll();
        }

        public void Initialize()
        {
            _isActive = true;
            AchievementsEventBus<CollisionEvent>.Register(OnCollision);
        }

        public void Destroy()
        {
            _isActive = false;
            AchievementsEventBus<CollisionEvent>.Unregister(OnCollision);
            SaveAll();
        }

        public AchievementInfo GetInfo()
        {
            return new AchievementInfo(GetTitle(), $"{_type}_{_collisionCount}", GetProgress(), _isActive);
        }

        private AchievementInfo.AchievementProgress GetProgress()
        {
            return new AchievementInfo.AchievementProgress(GetCurrentProgress(), _collisionCount);
        }

        private string GetTitle()
        {
            return _type switch
            {
                BarrierType.SimpleBox => $"Столкнитесь с коробкой {_collisionCount} раз",
                BarrierType.Opossum => $"Столкнитесь с опоссумом {_collisionCount} раз",
                BarrierType.HighEagle => $"Столкнитесь с высоко летающим орлом {_collisionCount} раз",
                BarrierType.LowEagle => $"Столкнитесь с низко летающим орлом {_collisionCount} Раз",
                BarrierType.Hp => $"Подберите доп. сердечки {_collisionCount} раз",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}