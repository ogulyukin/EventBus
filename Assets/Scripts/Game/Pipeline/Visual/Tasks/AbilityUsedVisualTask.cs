
namespace Game.Pipeline.Visual.Tasks
{
    public sealed class AbilityUsedVisualTask : PipelineTask
    {
        private readonly EntityConfig _targetEntity;

        public AbilityUsedVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override async void OnRun()
        {
            await _targetEntity.View.GetHeroAudio().PlayAbility();
            Finish();
        }
    }
}
