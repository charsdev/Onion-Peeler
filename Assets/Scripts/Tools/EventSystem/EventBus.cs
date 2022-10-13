using System.Collections.Generic;
using System;

namespace Chars.Tools
{ 
    public class EventBus
    {
		private static Dictionary<Type, List<EventListenerBase>> subscribers = new Dictionary<Type, List<EventListenerBase>>();

        public static void AddListener(EventListener listener)
		{
			Type eventType = typeof(GameEvent);

			if (!subscribers.ContainsKey(eventType))
				subscribers[eventType] = new List<EventListenerBase>();

			if (!SubscriptionExists(eventType, listener))
				subscribers[eventType].Add(listener);
		}

		public static void RemoveListener(EventListener listener)
		{
			Type eventType = typeof(GameEvent);

			if (!subscribers.ContainsKey(eventType))
				return;

			List<EventListenerBase> subscriberList = subscribers[eventType];

			for (int i = 0; i < subscriberList.Count; i++)
			{
				if (subscriberList[i] == listener)
				{
					subscriberList.Remove(subscriberList[i]);

					if (subscriberList.Count == 0)
                    {
						subscribers.Remove(eventType);
					}

					return;
				}
			}
		}

		public static void TriggerEvent(GameEvent newEvent)
		{
			List<EventListenerBase> list;
			if (!subscribers.TryGetValue(typeof(GameEvent), out list))
				return;

			for (int i = 0; i < list.Count; i++)
			{
				(list[i] as EventListener).OnEvent(newEvent);
			}
		}


		private static bool SubscriptionExists(Type type, EventListenerBase receiver)
		{
			List<EventListenerBase> receivers;

			if (!subscribers.TryGetValue(type, out receivers)) return false;

			bool exists = false;

			for (int i = 0; i < receivers.Count; i++)
			{
				if (receivers[i] == receiver)
				{
					exists = true;
					break;
				}
			}
			return exists;
		}
	}
}