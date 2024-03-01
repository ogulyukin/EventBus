using Game.Events;
using Game.Handlers.Turn;
using Game.Pipeline.Visual;
using Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.Visual
{
    [UsedImplicitly]
    public class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public AttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            _visualPipeline.AddTask(new AttackVisualTask(evt.Entity, evt.Target));
        }
    }
}
