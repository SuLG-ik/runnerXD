using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace World.Barriers
{
    [Serializable]
    public class Barrier
    {
        [SerializeField] public GameObject prefab;
        [SerializeField] public Vector2 spawnOffset;
    }
}