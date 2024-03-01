using JetBrains.Annotations;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public class GlobalAbilityTask : PipelineTask
    {
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public GlobalAbilityTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            var currentTeam = _entityStorage.GetTeam(_currentEntity.Value.Team);
            foreach (var entity in currentTeam)
            {
                if(entity.IsDead) continue;
                UseGlobalAbility(entity);
            }

            Finish();
        }

        private void UseGlobalAbility(EntityConfig entity)
        {
            if (entity.TryGetGlobalAbility(out var ability))
            {
                var tempCurrentEntity = new CurrentEntity() {Value = entity};
                ability.Run(_eventBus, tempCurrentEntity, _attackedEntity, _entityStorage);
            }
        }
    }
}
