using System;
using System.Collections.Generic;
using System.Linq;

namespace EnigmaDragons.Core.EventSystem
{
    public static class Event
    {
        private static readonly List<EventSubscription> EventSubs = new List<EventSubscription>();
        private static readonly Events TransientEvents = new Events();
        private static readonly Events PersistentEvents = new Events();
        private static readonly Events NetEvents = new Events();

        public static int SubscriptionCount => TransientEvents.SubscriptionCount + PersistentEvents.SubscriptionCount + NetEvents.SubscriptionCount;
        
        public static void Publish(object payload)
        {
            Logger.Write(payload);
            TransientEvents.Publish(payload);
            PersistentEvents.Publish(payload);
            NetEvents.Publish(payload);
        }

        public static void PublishLocally(object payload)
        {
            Logger.Write(payload);
            TransientEvents.Publish(payload);
            PersistentEvents.Publish(payload);
        }

        public static void NetSubscribe(EventSubscription subscription)
        {
            NetEvents.Subscribe(subscription);
            EventSubs.Add(subscription);
        }
        
        public static void SubscribeForever(EventSubscription subscription)
        {
            PersistentEvents.Subscribe(subscription);
        }

        public static void Subscribe<T>(Action<T> onEvent, object owner)
        {
            Subscribe(EventSubscription.Create<T>(onEvent, owner));
        }
        
        public static void Subscribe(EventSubscription subscription)
        {
            TransientEvents.Subscribe(subscription);
            EventSubs.Add(subscription);
        }

        public static void Unsubscribe(object owner)
        {
            TransientEvents.Unsubscribe(owner);
            PersistentEvents.Unsubscribe(owner);
            EventSubs
                .Where(x => x.Owner.Equals(owner))
                .ToList()
                .ForEach(x => EventSubs.Remove(x));
        }
    }
}
