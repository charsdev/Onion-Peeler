namespace Chars.Tools
{
    public static class EventRegister
	{
		public delegate void Delegate(GameEvent eventType);

		public static void EventStartListening(this EventListener caller)
		{
			EventBus.AddListener(caller);
		}

		public static void EventStopListening(this EventListener caller) 
		{
			EventBus.RemoveListener(caller);
		}
	}
}