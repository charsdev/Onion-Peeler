namespace Chars.Tools
{
    public class GameEvent
    {
        public string name;

        public GameEvent(string name)
        {
            this.name = name;
        }

        private static GameEvent gameEvent;

        public static void Trigger(string value)
        {
            gameEvent.name = value;
            EventBus.TriggerEvent(gameEvent);
        }
    }
}