using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utils
{
    [Serializable]
    public class Range
    {
        [SerializeField]
        public int start;
        [SerializeField]
        public int end;

        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}