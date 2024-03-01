using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class ActivateEntityVisualHandler : BaseHandler<ActivateEntity>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public ActivateEntityVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(ActivateEntity evt)
        {
            _visualPipeline.AddTask(new ActivateEntityVisualTask(evt.Entity));
        }
    }
}
