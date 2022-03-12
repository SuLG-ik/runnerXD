using UnityEngine.Events;

namespace Game.Events
{
    public class MutableMovementEvents : IMovementEvents
    {
        private event UnityAction OnJumpEvents;

        public void SendJumpEvent()
        {
            OnJumpEvents?.Invoke();
        }

        public void RegisterOnJumpListener(UnityAction callback)
        {
            OnJumpEvents += callback;
        }

        private event UnityAction JumpingEvents;

        public void SendJumpingEvent()
        {
            JumpingEvents?.Invoke();
        }

        public void RegisterJumpingListener(UnityAction callback)
        {
            JumpingEvents += callback;
        }

        private event UnityAction FallingEvents;

        public void SendFallingEvent()
        {
            FallingEvents?.Invoke();
        }

        public void RegisterFallingListener(UnityAction callback)
        {
            FallingEvents += callback;
        }

        private event UnityAction RunningEvents;

        public void SendRunningEvent()
        {
            RunningEvents?.Invoke();
        }

        public void RegisterRunningListener(UnityAction callback)
        {
            RunningEvents += callback;
        }

        
    }
}