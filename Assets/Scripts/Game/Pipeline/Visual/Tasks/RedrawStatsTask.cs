using UnityEngine;

namespace Game.Pipeline.Visual.Tasks
{
    public sealed class RedrawStatsTask : PipelineTask
    {
        private readonly EntityConfig _entity;

        public RedrawStatsTask(EntityConfig entity)
        {
            _entity = entity;
        }

        protected override void OnRun()
        {
            _entity.View.SetStats($"{_entity.Damage}/{_entity.CurrentHealth}");
            Finish();
        }
    }
}
