using System;
using Achievement.Events;
using Achievement.Processor;
using Game;
using UnityEngine;
using UnityEngine.Events;
using World.Barriers;
using Zenject;

namespace Achievement.Handlers
{
    public class CollisionAchievementBuilder : AchievementBuilder
    {
        [SerializeField] private int collisionCount;

        [SerializeField] private BarrierType type;


        public override IAchievementHandler Build(Action<IAchievementHandler> onComplete, Action<IAchievementHandler> onUpdate)
        {
            return new CollisionAchievementHandler(collisionCount, type, onComplete, onUpdate);
        }
    }
}