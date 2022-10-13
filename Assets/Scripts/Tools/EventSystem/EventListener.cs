namespace Chars.Tools
{
    public interface EventListener : EventListenerBase
	{
		void OnEvent(GameEvent eventType);
	}
}