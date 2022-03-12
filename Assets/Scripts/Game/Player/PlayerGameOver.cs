using Game.Level;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.Player
{
    [RequireComponent(typeof(IPlayer))]
    public class PlayerGameOver: MonoBehaviour
    {
        [Inject]
        private INavigator _navigator;
        [Inject]
        private IProgressSaver _progressSaver;
        
        
        private void Start()
        {
            var player = GetComponent<IPlayer>();
            var scoreboard = player.GetScoreboard();
            player.GetPlayerHealth().RegisterDieListener(() =>
            {
                _progressSaver.SaveProgress(scoreboard.GetCurrentScore());
                _navigator.NavigateToGameOver();
            });
        }
    }
}