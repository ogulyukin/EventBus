using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        public DestroyHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            evt.Entity.IsDead = true;
        }
    }
}
