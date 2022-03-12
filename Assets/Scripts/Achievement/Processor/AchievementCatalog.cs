using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Achievement.Processor
{
    public class AchievementCatalog : MonoBehaviour, IAchievementsCatalog
    {
        [SerializeField] public List<AchievementBuilder> builders;

        public List<IAchievementHandler> GetAchievementHandlers(Action<IAchievementHandler> onComplete, Action<IAchievementHandler> onUpdate)
        {
            return builders.Select((builder) => builder.Build(onComplete, onUpdate)).ToList();
        }
    }
}