namespace Game.Events
{
    public readonly struct RedrawStatEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public RedrawStatEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
