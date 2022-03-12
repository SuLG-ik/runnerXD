using System.Collections.Generic;

namespace World.Barriers
{
    public interface IBarrierCollection
    {
        public List<Barrier> GetBarriers();

        public Barrier PickRandom();
    }
}