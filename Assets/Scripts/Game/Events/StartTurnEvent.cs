namespace Game.Events
{
    public class StartTurnEvent : IEvent
    {
        public readonly int Turn;

        public StartTurnEvent(int turn)
        {
            Turn = turn;
        }
    }
}
