using System.Collections.Generic;
using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class StartGameTask : PipelineTask
    {
        private bool _gameStarted;
        private readonly EventBus _eventBus;
        private readonly EntityStorage _entityStorage;
        private readonly CurrentEntity _currentEntity;
        private readonly StartVisualPipelineTask _startVisualPipelineTask;

        public StartGameTask(EventBus eventBus, EntityStorage entityStorage, CurrentEntity currentEntity, StartVisualPipelineTask startVisualPipelineTask)
        {
            _eventBus = eventBus;
            _entityStorage = entityStorage;
            _currentEntity = currentEntity;
            _startVisualPipelineTask = startVisualPipelineTask;
        }

        public void ResetGameStart()
        {
            _gameStarted = false;
        }

        protected override void OnRun()
        {
            if (_gameStarted)
            {
                Finish();
                return;
            }
            Debug.Log("StartGameTask");
            var entities = new List<EntityConfig>();
            entities.AddRange(_entityStorage.GetTeam(true));
            entities.AddRange(_entityStorage.GetTeam(false));
            ResetEntities(entities);
            foreach (var entity in entities)
            {
                _eventBus.RaiseEvent(new RedrawStatEvent(entity));
            }

            if (_currentEntity.Value != null)
            {
                _eventBus.RaiseEvent(new DeactivateEntityEvent(_currentEntity.Value));
            }
            _currentEntity.Value = _entityStorage.GetStartEntity();
            _eventBus.RaiseEvent(new ActivateEntity(_currentEntity.Value));
            _gameStarted = true;
            _startVisualPipelineTask.Run(Finish);
        }

        private void ResetEntities(List<EntityConfig> entities)
        {
            foreach (var entity in entities)
            {
                entity.CurrentHealth = entity.Health;
                entity.IsDead = false;
                entity.gameObject.SetActive(true);
            }
        }
    }
}
