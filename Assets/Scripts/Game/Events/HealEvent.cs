namespace Game.Events
{
    public class HealEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;
        public readonly int HealAmount;

        public HealEvent(EntityConfig targetEntity, int healAmount)
        {
            TargetEntity = targetEntity;
            HealAmount = healAmount;
        }
    }
}
