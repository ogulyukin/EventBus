using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class SwitchHeroVisualHandler : BaseHandler<SwitchHeroEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public SwitchHeroVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(SwitchHeroEvent evt)
        {
            _visualPipeline.AddTask(new SwitchHeroVisualTask(evt.Entity));
        }
    }
}
