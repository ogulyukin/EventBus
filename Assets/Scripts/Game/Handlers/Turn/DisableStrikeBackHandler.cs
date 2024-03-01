using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public class DisableStrikeBackHandler : BaseHandler<DisableStrikeBackEvent>
    {
        public DisableStrikeBackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DisableStrikeBackEvent evt)
        {
            evt.TargetEntity.CantStrikeBack = true;
        }
    }
}
