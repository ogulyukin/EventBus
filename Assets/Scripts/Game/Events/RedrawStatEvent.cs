namespace Game.Events
{
    public class RedrawStatEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public RedrawStatEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
