
namespace Game.Pipeline.Visual.Tasks
{
    public sealed class DestroyVisualTask : PipelineTask
    {
        private readonly EntityConfig _targetEntity;

        public DestroyVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override async void OnRun()
        {
            _targetEntity.IsDead = true;
            await _targetEntity.View.GetHeroAudio().PlayDeath();
            _targetEntity.gameObject.SetActive(false);
            Finish();
        }
    }
}
