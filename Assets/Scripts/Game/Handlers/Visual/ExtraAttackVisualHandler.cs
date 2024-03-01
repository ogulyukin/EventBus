using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class ExtraAttackVisualHandler : BaseHandler<ExtraAttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public ExtraAttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(ExtraAttackEvent evt)
        {
            _visualPipeline.AddTask(new AttackVisualTask(evt.SourceEntity, evt.TargetEntity));
        }
    }
}
