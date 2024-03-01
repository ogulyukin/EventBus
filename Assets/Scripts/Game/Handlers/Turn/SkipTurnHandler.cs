using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public class SkipTurnHandler : BaseHandler<SkipTurnEvent>
    {
        public SkipTurnHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(SkipTurnEvent evt)
        {
            evt.TargetEntity.SkipTurn = true;
        }
    }
}
