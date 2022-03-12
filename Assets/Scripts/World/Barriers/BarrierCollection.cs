using System.Collections.Generic;
using UnityEngine;

namespace World.Barriers
{
    public class BarrierCollection: MonoBehaviour, IBarrierCollection
    {

        [SerializeField] private List<Barrier> barriers;
        
        public List<Barrier> GetBarriers()
        {
            return barriers;
        }

        public Barrier PickRandom()
        {
            return barriers[Random.Range(0, barriers.Count)];
        }
        
    }
}