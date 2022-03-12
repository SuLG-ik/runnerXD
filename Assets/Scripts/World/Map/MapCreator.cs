using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

namespace World.Map
{
    public class MapCreator : SuspendableMonoBehaviour, IMapCreator
    {
        private MapsCollection _mapsCollection;

        [SerializeField] private Vector2 initialMapSpawn;

        private readonly List<Map> _maps = new List<Map>();

        protected override void Start()
        {
            base.Start();
            _mapsCollection = FindObjectOfType<MapsCollection>();
            GenerateNextMap();
            GenerateNextMap();
        }

        public override void Suspend()
        { }

        public override void Continue() { }

        public void DestroyAndSpawnMap(Map map)
        {
            _maps.Remove(map);
            Destroy(map.gameObject);
            GenerateNextMap();
        }

        [CanBeNull]
        private Map GetLastMap()
        {
            return _maps.Count > 0 ? _maps.Last() : null;
        }

        private void GenerateNextMap()
        {
            var lastMapPosition = GetLastMap()?.transform.position;
            if (lastMapPosition == null)
            {
                OnSpawnMap(initialMapSpawn);
                return;
            }

            var newPosition = new Vector2(lastMapPosition.Value.x + 23, lastMapPosition.Value.y);
            OnSpawnMap(newPosition);
        }

        private void OnSpawnMap(Vector2 position)
        {
            var map = Instantiate(
                _mapsCollection.scenes[Random.Range(0, _mapsCollection.scenes.Count)].prefab,
                position,
                Quaternion.identity
            );
            _maps.Add(map.GetComponent<Map>());
        }
    }
}