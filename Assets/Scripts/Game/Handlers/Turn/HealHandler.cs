using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public class HealHandler : BaseHandler<HealEvent>
    {
        public HealHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(HealEvent evt)
        {
            Debug.Log($"HealHandler: {evt.TargetEntity.Name}, {evt.HealAmount}");
            evt.TargetEntity.CurrentHealth =
                Mathf.Min(evt.TargetEntity.Health, evt.TargetEntity.CurrentHealth + evt.HealAmount);
        }
    }
}
