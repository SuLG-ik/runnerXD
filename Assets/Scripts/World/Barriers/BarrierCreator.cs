using System;
using System.Collections.Generic;
using Game;
using Game.Level;
using JetBrains.Annotations;
using UnityEngine;
using Utils;
using World.Map;
using Zenject;
using Random = UnityEngine.Random;

namespace World.Barriers
{
    public class BarrierCreator : SuspendableMonoBehaviour, IBarrierCreator
    {
        [SerializeField] private Vector2 initialBarrierSpawner;

        private ILevelConfig _levelConfig;

        private IBarrierCollection _collection;

        private int _nextBarrierSpawn;

        private readonly List<IBarrier> _barriers = new List<IBarrier>();

        [SerializeField] private Range spawnRange = new Range(1000, 2000);

        private IState _state = new Continued();

        protected override void Start()
        {
            base.Start();
            _collection = FindObjectOfType<BarrierCollection>();
            _levelConfig = FindObjectOfType<ScoredLevelConfig>();
        }

        private void Update()
        {
            _state.Update(this);
        }

        private static int GetCurrentTimeMillis()
        {
            return (int) Time.time * 1000;
        }


        private void Generate()
        {
            var barrier = _collection.PickRandom();
            var barrierObject = Instantiate(barrier.prefab, initialBarrierSpawner + barrier.spawnOffset,
                Quaternion.identity);
            _barriers.Add(barrierObject.GetComponent<IBarrier>());
        }

        public int GetBarrierMovement()
        {
            return _levelConfig.GetCurrentStaticBarrierSpeed();
        }


        public void DestroyBarrier(IBarrier barrier)
        {
            Destroy(barrier.GetGameObject());
            _barriers.Remove(barrier);
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
            public void Update(BarrierCreator creator);
        }

        private sealed class Suspended : IState
        {
            public void Update(BarrierCreator creator)
            {
                throw new NotImplementedException();
            }
        }

        private sealed class Continued : IState
        {
            public void Update(BarrierCreator creator)
            {
                if (creator._nextBarrierSpawn - GetCurrentTimeMillis() >= 0) return;
                creator._nextBarrierSpawn = GetCurrentTimeMillis() +
                                            (int) (Random.Range(creator.spawnRange.start, creator.spawnRange.end) *
                                                   creator._levelConfig.GetBarrierSpawnDelta());
                creator.Generate();
            }
        }
    }
}