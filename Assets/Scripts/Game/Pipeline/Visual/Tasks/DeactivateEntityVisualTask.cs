using JetBrains.Annotations;

namespace Game.Pipeline.Visual.Tasks
{
    
    public class DeactivateEntityVisualTask : PipelineTask
    {
        private readonly EntityConfig _sourceEntity;

        public DeactivateEntityVisualTask(EntityConfig sourceEntity)
        {
            _sourceEntity = sourceEntity;
        }

        protected override void OnRun()
        {
            _sourceEntity.View.SetActive(false);
            Finish();
        }
    }
}
