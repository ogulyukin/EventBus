using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public class HealVisualHandler : BaseHandler<HealEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public HealVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(HealEvent evt)
        {
            _visualPipeline.AddTask(new HealVisualTask(evt.TargetEntity));
        }
    }
}
