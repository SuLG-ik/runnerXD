using UnityEngine.Events;

namespace Game.Player
{
    public interface IPlayerHealth
    {

        public int GetCurrentHealth();

        public int UpdateHealth(int delta);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback">first param: health, second param: delta health</param>
        public void RegisterUpdateHeathListener(UnityAction<int, int> callback);
        
        public void RegisterDieListener(UnityAction callback);

    }
}