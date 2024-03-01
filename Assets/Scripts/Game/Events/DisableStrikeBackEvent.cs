namespace Game.Events
{
    public class DisableStrikeBackEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public DisableStrikeBackEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
