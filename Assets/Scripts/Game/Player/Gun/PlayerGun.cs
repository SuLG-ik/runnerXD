using System;
using Game.Player.Gun;
using UnityEditor.UIElements;
using UnityEngine.Events;

namespace Game.Player
{
    public class PlayerGun : IPlayerGun
    {
        private int _amount;
        private event UnityAction ShootListener;
        private event UnityAction<int, int> UpdateAmountListener;


        public int GetBulletsAmount()
        {
            return _amount;
        }

        public int UpdateBulletsAmount(int delta)
        {
            _amount = Math.Min(3, Math.Max(0, _amount + delta));
            SendUpdateAmountEvent(_amount, delta);
            if (_amount <= 0)
                return _amount = 0;

            return _amount;
        }

        public bool Shoot()
        {
            if (_amount <= 0)
                return false;
            UpdateBulletsAmount(-1);
            ShootListener?.Invoke();
            return true;
        }

        public void RegisterUpdateBulletsAmountListener(UnityAction<int, int> listener)
        {
            UpdateAmountListener += listener;
        }

        public void RegisterShootListener(UnityAction listener)
        {
            ShootListener += listener;
        }

        private void SendUpdateAmountEvent(int amount, int delta)
        {
            UpdateAmountListener?.Invoke(amount, delta);
        }
    }
}