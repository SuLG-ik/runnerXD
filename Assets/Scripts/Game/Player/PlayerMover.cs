using System.Runtime.InteropServices;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D), typeof(IPlayer))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField, Range(1f, 100f)] private float jumpImpulse = 5f;

        private void Start()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            var player = GetComponent<IPlayer>();
            var movementListener = player.GetMovementEvents();
            movementListener.RegisterOnJumpListener(() => { rigidbody.velocity += new Vector2(0f, jumpImpulse); });
        }
    }
}