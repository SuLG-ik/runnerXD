using UnityEngine.Events;

namespace Game.Events
{
    public interface IMovementEvents
    {
        public void RegisterOnJumpListener(UnityAction callback);
        
        public void RegisterJumpingListener(UnityAction callback);        
        
        public void RegisterFallingListener(UnityAction callback);

        public void RegisterRunningListener(UnityAction callback);
        

    }
}