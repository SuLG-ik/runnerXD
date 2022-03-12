using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Achievement.Processor
{
    public abstract class AchievementBuilder : MonoBehaviour
    {
        public abstract IAchievementHandler Build(Action<IAchievementHandler> onComplete, Action<IAchievementHandler> onUpdate);
    }
}