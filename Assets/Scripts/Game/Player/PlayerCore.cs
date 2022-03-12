using System;
using Game.Events;
using Game.Player.Gun;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D)),
     RequireComponent(typeof(IPlayerHealth), typeof(IScoreboard), typeof(IPlayerGun))]
    public class PlayerCore : SuspendableMonoBehaviour, IPlayer
    {
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;

        private readonly MutableMovementEvents _movementEvents = new MutableMovementEvents();

        private IPlayerHealth _playerHealth;

        private IScoreboard _scoreboard;

        private IPlayerGun _playerGun = new PlayerGun();

        private IState _state = new Continued();

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            _state.Update(this);
        }

        private void HandleMovements()
        {
            if (!IsJumping() && Input.GetKeyDown(KeyCode.Space))
            {
                _movementEvents.SendJumpEvent();
            }

            if (_rigidbody.velocity.y >= 0.05f)
            {
                _movementEvents.SendJumpingEvent();
            }
            else if (_rigidbody.velocity.y <= -0.05f)
            {
                _movementEvents.SendFallingEvent();
            }
            else
            {
                _movementEvents.SendRunningEvent();
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetGun().Shoot();
            }
        }

        private bool IsJumping()
        {
            var raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.down,
                _boxCollider.bounds.extents.y + 0.05f, groundMask);
            var color = raycastHit.collider == null ? Color.red : Color.green;
            Debug.DrawRay(_boxCollider.bounds.center, Vector3.down * (_boxCollider.bounds.extents.y + 0.1f), color);
            return raycastHit.collider == null;
        }

        public IMovementEvents GetMovementEvents()
        {
            return _movementEvents;
        }

        public IPlayerHealth GetPlayerHealth()
        {
            return _playerHealth ??= GetComponent<IPlayerHealth>();
        }

        public IScoreboard GetScoreboard()
        {
            return _scoreboard ??= GetComponent<IScoreboard>();
        }

        public IPlayerGun GetGun()
        {
            return _playerGun;
        }

        public override void Suspend()
        {
            _state = new Suspended();
        }

        public override void Continue()
        {
            _state = new Continued();
        }

        private interface IState
        {
            public void Update(PlayerCore player);
        }

        private sealed class Suspended : IState
        {
            public void Update(PlayerCore player)
            {
            }
        }

        private sealed class Continued : IState
        {
            public void Update(PlayerCore player)
            {
                player.HandleMovements();
            }
        }
    }
}