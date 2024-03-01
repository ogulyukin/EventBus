using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class ExtraAttackHandler : BaseHandler<ExtraAttackEvent>
    {
        public ExtraAttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(ExtraAttackEvent evt)
        {
            EventBus.RaiseEvent(new DealDamageEvent(evt.TargetEntity, evt.Damage));
            Debug.Log($"ExtraAttackHandler: {evt.TargetEntity.Name}, {evt.Damage}");
        }
    }
}
