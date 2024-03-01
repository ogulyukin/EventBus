namespace Game.Pipeline.Visual.Tasks
{
    public class HealVisualTask : PipelineTask
    {
        private readonly EntityConfig _targetEntity;

        public HealVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.View.Heal();
            Finish();
        }
    }
}
