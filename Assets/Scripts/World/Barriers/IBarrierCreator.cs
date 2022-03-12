namespace World.Barriers
{
    public interface IBarrierCreator
    {

        public int GetBarrierMovement();

        public void DestroyBarrier(IBarrier barrier);

    }
}