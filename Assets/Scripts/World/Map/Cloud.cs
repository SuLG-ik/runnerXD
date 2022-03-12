using System;
using Game.Level;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace World.Map
{
    public class Cloud : SuspendableMonoBehaviour
    {
        private ILevelConfig _levelConfig;
        private CloudsParallax _cloudsParallax;
        private IState currentState = new Suspended();

        protected override void Start()
        {
            base.Start();
            _levelConfig = FindObjectOfType<ScoredLevelConfig>();
            _cloudsParallax = FindObjectOfType<CloudsParallax>();
        }

        private void Update()
        {
            currentState.Update(this);
        }

        public override void Suspend()
        {
            currentState = new Suspended();
        }

        public override void Continue()
        {
            currentState = new Continued();
        }

        private interface IState
        {
            public void Update(Cloud cloud);
        }

        private sealed class Suspended : IState
        {
            public void Update(Cloud cloud)
            {
                
            }
        }

        private sealed class Continued : IState
        {
            public void Update(Cloud cloud)
            {
                var position = cloud.gameObject.transform.position;
                var newPosition = new Vector2(position.x + cloud._levelConfig.GetCurrentCloudSpeed() * Time.deltaTime,
                    position.y);
                cloud.gameObject.transform.position = newPosition;
                if (cloud.transform.position.x <= -23)
                {
                    cloud._cloudsParallax.DestroyAndSpawnClouds(cloud);
                }
            }
        }
    }
}