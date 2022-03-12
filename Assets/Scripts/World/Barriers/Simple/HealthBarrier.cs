
using Game.Player;
using UnityEngine;

namespace World.Barriers.Simple
{
    public abstract class HealthBarrier : MovableBarrier
    {
        
        protected abstract IPlayerHealth GetHealth();
        
        private bool _isTriggered;
        
        protected abstract int GetHealthDelta();

        public override void OnCollision()
        {
            if (_isTriggered) return;
            _isTriggered = true;
            GetHealth().UpdateHealth(GetHealthDelta());
            Destroy(gameObject);
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }
        
    }
}