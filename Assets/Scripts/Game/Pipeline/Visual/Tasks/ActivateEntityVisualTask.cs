namespace Game.Pipeline.Visual.Tasks
{
    public sealed class ActivateEntityVisualTask : PipelineTask
    {
        private readonly EntityConfig _sourceEntity;

        public ActivateEntityVisualTask(EntityConfig sourceEntity)
        {
            _sourceEntity = sourceEntity;
        }

        protected override void OnRun()
        {
            _sourceEntity.View.SetActive(true);
            Finish();
        }
    }
}
