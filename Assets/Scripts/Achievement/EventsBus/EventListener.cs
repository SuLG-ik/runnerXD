using Achievement.Events;

namespace Achievement.EventsBus
{
    public delegate void EventListener<in T>(T @event) where  T: struct, IEvent;
}