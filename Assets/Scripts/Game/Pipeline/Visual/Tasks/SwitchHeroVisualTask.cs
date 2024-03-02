
namespace Game.Pipeline.Visual.Tasks
{
    public sealed class SwitchHeroVisualTask : PipelineTask
    {
        private readonly EntityConfig _targetEntity;

        public SwitchHeroVisualTask (EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override async void OnRun()
        {
            await _targetEntity.View.GetHeroAudio().PlayStatTurn();
            Finish();
        }
    }
}
