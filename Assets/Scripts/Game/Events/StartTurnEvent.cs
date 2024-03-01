namespace Game.Events
{
    public readonly struct StartTurnEvent : IEvent
    {
        public readonly int Turn;

        public StartTurnEvent(int turn)
        {
            Turn = turn;
        }
    }
}
