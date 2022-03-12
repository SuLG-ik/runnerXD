using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Animator), typeof(IPlayer))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        

        private void Start()
        {
            var player = GetComponent<IPlayer>();
            var movementEvents = player.GetMovementEvents();
            var health = player.GetPlayerHealth();
            _animator = GetComponent<Animator>();
            movementEvents.RegisterRunningListener(() => { _animator.Play("run"); });
            movementEvents.RegisterJumpingListener(() => { _animator.Play("jump"); });
            movementEvents.RegisterFallingListener(() => { _animator.Play("fall"); });
            health.RegisterUpdateHeathListener((_, delta) =>
            {
                _animator.SetTrigger(delta < 0 ? "hit": "heal");
            });
        }
    }
}