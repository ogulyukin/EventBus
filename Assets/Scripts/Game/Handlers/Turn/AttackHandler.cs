using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, evt.Entity.Damage));
            Debug.Log($"Attack Handler: {evt.Target.Name}, {evt.Entity.Damage}");
        }
    }
}
