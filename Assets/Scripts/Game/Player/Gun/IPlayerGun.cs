using UnityEngine.Events;

namespace Game.Player.Gun
{
    public interface IPlayerGun
    {
        
        public int GetBulletsAmount();

        public int UpdateBulletsAmount(int delta);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener">param1: new amoun, param2: delta</param> 
        /// <returns></returns>
        public void RegisterUpdateBulletsAmountListener(UnityAction<int, int> listener);

        public void RegisterShootListener(UnityAction listener);


        public bool Shoot();

    }
}