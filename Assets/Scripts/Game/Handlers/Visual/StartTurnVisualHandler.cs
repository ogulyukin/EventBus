using Game.Events;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public class StartTurnVisualHandler : BaseHandler<StartTurnEvent>
    {
        public StartTurnVisualHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(StartTurnEvent evt)
        {
            //Here can be added visual task for start each turn;
        }
    }
}
