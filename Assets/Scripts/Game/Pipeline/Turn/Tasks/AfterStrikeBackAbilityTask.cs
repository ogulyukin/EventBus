using JetBrains.Annotations;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public class AfterStrikeBackAbilityTask : PipelineTask
    {
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public AfterStrikeBackAbilityTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_attackedEntity.Value.TryGetAfterStrikeBackAbility(out var ability))
            {
                ability.Run(_eventBus, _currentEntity, _attackedEntity, _entityStorage);
            }
            Finish();
        }
    }
}
