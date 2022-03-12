using Game.Events;
using Game.Player.Gun;

namespace Game.Player
{
    public interface IPlayer
    {
        public IMovementEvents GetMovementEvents();

        public IPlayerHealth GetPlayerHealth();

        public IScoreboard GetScoreboard();

        public IPlayerGun GetGun();
    }
}