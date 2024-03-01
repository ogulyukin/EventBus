using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class SwitchHeroTask : PipelineTask
    {
        private readonly EventBus _eventBus;
        private readonly EntityStorage _entityStorage;
        private readonly CurrentEntity _currentEntity;

        public SwitchHeroTask(EventBus eventBus, EntityStorage entityStorage, CurrentEntity currentEntity)
        {
            _eventBus = eventBus;
            _entityStorage = entityStorage;
            _currentEntity = currentEntity;
        }

        protected override void OnRun()
        {
            Debug.Log("Switching Hero");
            if (!_entityStorage.HasAliveHeroes(!_currentEntity.Value.Team))
            {
                Finish();
                return;
            }
            var previousEntity = _currentEntity.Value;
            _currentEntity.Value = _entityStorage.GetNextEntity(!_currentEntity.Value.Team);
            
            if (_currentEntity.Value.SkipTurn)
            {
                _currentEntity.Value.SkipTurn = false;
                var storedEntity = _currentEntity.Value;
                _currentEntity.Value = _entityStorage.GetNextEntity(_currentEntity.Value.Team);
                if (storedEntity == _currentEntity.Value)
                {
                    _currentEntity.Value = _entityStorage.GetNextEntity(!_currentEntity.Value.Team);
                }
            }
            
            _eventBus.RaiseEvent(new ActivateEntity(_currentEntity.Value));
            _eventBus.RaiseEvent(new DeactivateEntityEvent(previousEntity));
            _eventBus.RaiseEvent(new SwitchHeroEvent(_currentEntity.Value));
            Finish();
        }
    }
}
