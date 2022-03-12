using Achievement;
using Achievement.Events;
using Achievement.EventsBus;
using Game;
using Game.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace World.Barriers.Simple
{
    public class TypedHealthBarrier : HealthBarrier
    {
        [SerializeField, Range(-3, 3)] private int healthDelta = 1;
        [SerializeField] private BarrierType type;

        private IPlayerHealth _playerHealth;

        protected override int GetHealthDelta()
        {
            return healthDelta;
        }

        protected override IPlayerHealth GetHealth()
        {
            return _playerHealth ??= FindObjectOfType<PlayerCore>().GetPlayerHealth();
        }

        public override void OnCollision()
        {
            AchievementsEventBus<CollisionEvent>.Raise(new CollisionEvent(type));
            base.OnCollision();
        }
    }
}