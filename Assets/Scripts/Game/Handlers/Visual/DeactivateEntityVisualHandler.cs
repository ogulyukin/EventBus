using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class DeactivateEntityVisualHandler : BaseHandler<DeactivateEntityEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public DeactivateEntityVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DeactivateEntityEvent evt)
        {
            _visualPipeline.AddTask(new DeactivateEntityVisualTask(evt.Entity));
        }
    }
}
