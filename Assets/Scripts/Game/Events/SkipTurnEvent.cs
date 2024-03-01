
namespace Game.Events
{
    public class SkipTurnEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public SkipTurnEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
