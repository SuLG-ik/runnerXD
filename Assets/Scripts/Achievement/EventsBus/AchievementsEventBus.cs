using System;
using System.Collections.Generic;
using Achievement.Events;

namespace Achievement.EventsBus
{
    public static class AchievementsEventBus<T> where T : struct, IEvent
    {
        private static EventListener<T>[] _buffer = Array.Empty<EventListener<T>>();
        private static int _count;
        private static readonly int Blocksize = 256;

        private static readonly HashSet<EventListener<T>> Hash = new HashSet<EventListener<T>>();

        public static void Register(EventListener<T> handler)
        {
            _count++;
            Hash.Add(handler);
            if (_buffer.Length < _count)
            {
                _buffer = new EventListener<T>[_count + Blocksize];
            }

            Hash.CopyTo(_buffer);
        }

        public static void Unregister(EventListener<T> handler)
        {
            Hash.Remove(handler);
            Hash.CopyTo(_buffer);
            _count--;
        }

        public static void Raise(T e)
        {
            foreach (var eventListener in _buffer)
            {
                eventListener?.Invoke(e);
            }
        }
    }
}