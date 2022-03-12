namespace Game.Level
{
    public interface ILevelConfig
    {

        public int GetCurrentScoreDelta();

        public int GetCurrentMapSpeed();

        public int GetCurrentStaticBarrierSpeed();
        public float GetBarrierSpawnDelta();
        public float GetCurrentCloudSpeed();


    }
}