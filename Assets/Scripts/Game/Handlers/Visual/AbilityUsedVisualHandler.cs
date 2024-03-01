using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class AbilityUsedVisualHandler : BaseHandler<AbilityUsedEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public AbilityUsedVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(AbilityUsedEvent evt)
        {
            _visualPipeline.AddTask(new AbilityUsedVisualTask(evt.TargetEntity));
        }
    }
}
