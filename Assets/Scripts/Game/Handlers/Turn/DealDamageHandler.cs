using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

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
            Debug.Log($"Deal damage Handler: {evt.Entity.Name}, {evt.Damage}");
            evt.Entity.CurrentHealth -= evt.Damage;
            if (evt.Entity.CurrentHealth <= 0)
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
            Debug.Log($"Deal damage Handler: {evt.Entity.Name}, Health: {evt.Entity.CurrentHealth}/{evt.Entity.Health}");
        }
    }
}
