using System;
using Game.Player;
using UnityEngine;
using UnityEngine.Events;
using World.Barriers;

namespace Game
{
    public class PlayerHealth : MonoBehaviour, IPlayerHealth
    {
        private int _health = 3;

        public int GetCurrentHealth()
        {
            return _health = Math.Max(0, _health);
        }

        public int UpdateHealth(int delta)
        {
            _health = Math.Min(3, Math.Max(0, _health + delta));
            if (_health <= 0)
            {
                SendDieEvent();
            }
            SendUpdateHeathEvent(_health, delta);

            return _health;
        }

        private event UnityAction DieEvents;

        public void RegisterDieListener(UnityAction callback)
        {
            DieEvents += callback;
        }

        private void SendDieEvent()
        {
            DieEvents?.Invoke();
        }

        private event UnityAction<int, int> UpdateHeath;

        public void RegisterUpdateHeathListener(UnityAction<int, int> callback)
        {
            UpdateHeath += callback;
        }

        private void SendUpdateHeathEvent(int newDamage, int delta)
        {
            UpdateHeath?.Invoke(newDamage, delta);
        }


    }
}