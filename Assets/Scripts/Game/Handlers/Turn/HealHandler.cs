using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class HealHandler : BaseHandler<HealEvent>
    {
        public HealHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(HealEvent evt)
        {
            evt.TargetEntity.CurrentHealth =
                Mathf.Min(evt.TargetEntity.Health, evt.TargetEntity.CurrentHealth + evt.HealAmount);
        }
    }
}
