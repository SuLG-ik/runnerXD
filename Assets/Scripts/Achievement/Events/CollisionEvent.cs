using System;
using World.Barriers;

namespace Achievement.Events
{
    public struct CollisionEvent : IEvent
    {
        public BarrierType Type { get; }

        public CollisionEvent(BarrierType type)
        {
            Type = type;
        }
    }
}