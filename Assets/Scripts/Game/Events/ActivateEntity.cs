
namespace Game.Events
{
    public class ActivateEntity : IEvent
    {
        public readonly EntityConfig Entity;

        public ActivateEntity(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
