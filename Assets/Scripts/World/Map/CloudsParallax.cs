using System;
using Game.Level;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace World.Map
{
    public class CloudsParallax : SuspendableMonoBehaviour
    {
        [SerializeField] private Cloud cloud1;
        [SerializeField] private Cloud cloud2;

        [SerializeField] private Vector2 initialCloudSpawn;

        private ILevelConfig _levelConfig;

        protected override void Start()
        {
            base.Start();
            _levelConfig = FindObjectOfType<ScoredLevelConfig>();
        }

        public void DestroyAndSpawnClouds(Cloud cloud)
        {
            var position = GetAnotherCloud(cloud).gameObject.transform.position;
            var newPosition = new Vector2(position.x + 46, position.y);
            cloud.gameObject.transform.position = newPosition;
        }

        private Cloud GetAnotherCloud(Cloud cloud)
        {
            return cloud == cloud1 ? cloud1 : cloud2;
        }

        public override void Suspend()
        {
        }

        public override void Continue()
        {
        }
    }
}