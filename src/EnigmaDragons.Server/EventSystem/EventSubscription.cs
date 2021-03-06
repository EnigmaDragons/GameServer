﻿using System;

namespace EnigmaDragons.Core.EventSystem
{
    public sealed class EventSubscription : IDisposable
    {
        public Type EventType { get; }
        public Action<object> OnEvent { get; }
        public object Owner { get; }

        internal EventSubscription(Type eventType, Action<object> onEvent, object owner)
        {
            EventType = eventType;
            OnEvent = onEvent;
            Owner = owner;
        }

        public void Dispose()
        {
            Event.Unsubscribe(Owner);
        }      
        
        public static EventSubscription Create<T>(Action<T> onEvent, object owner)
        {
            return new EventSubscription(typeof(T), (o) => { if (o.GetType() == typeof(T)) onEvent((T)o); }, owner);
        }
    }
}
