using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            evt.Entity.CurrentHealth -= evt.Damage;
            if (evt.Entity.CurrentHealth <= 0)
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
        }
    }
}
