using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class RedrawStatsVisualHandler : BaseHandler<RedrawStatEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public RedrawStatsVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(RedrawStatEvent evt)
        {
            _visualPipeline.AddTask(new RedrawStatsTask(evt.Entity));
        }
    }
}
