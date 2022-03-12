using Game.Level;
using UnityEngine;
using Zenject;

namespace World.Map
{
    public abstract class Map : SuspendableMonoBehaviour
    {
        private MapCreator _mapCreator;

        private ILevelConfig _levelConfig;

        private IState _state = new Continued();

        protected override void Start()
        {
            base.Start();
            _levelConfig = FindObjectOfType<ScoredLevelConfig>();
            _mapCreator = FindObjectOfType<MapCreator>();
        }

        private void Update()
        {
            _state.Update(this);
        }

        public override void Suspend()
        {
            _state = new Suspended();
        }

        public override void Continue()
        {
            _state = new Continued();
        }

        private interface IState
        {
            public void Update(Map map);
        }

        private sealed class Suspended : IState
        {
            public void Update(Map map)
            {
            }
        }

        private sealed class Continued : IState
        {
            public void Update(Map map)
            {
                var position = map.gameObject.transform.position;
                var newPosition = new Vector2(position.x + map._levelConfig.GetCurrentMapSpeed() * Time.deltaTime,
                    position.y);
                map.gameObject.transform.position = newPosition;
                if (map.transform.position.x <= -25)
                {
                    map._mapCreator.DestroyAndSpawnMap(map);
                }
            }
        }
    }
}