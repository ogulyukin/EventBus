using System.Collections.Generic;
using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class PlayerTurnTask : PipelineTask
    {
        private readonly List<EntityButtonListener> _buttonsListener;
        private readonly EventBus _eventBus;
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;

        public PlayerTurnTask(List<EntityButtonListener> buttonsListener, EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity)
        {
            _buttonsListener = buttonsListener;
            _eventBus = eventBus;
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
        }

        protected override void OnRun()
        {
            Debug.Log($"Player turn. {_currentEntity.Value.Name} wait");
            foreach (var listener in _buttonsListener)
            {
                listener.OnTargetClicked += OnTargetClicked;    
            }
        }

        protected override void OnFinish()
        {
            foreach (var listener in _buttonsListener)
            {
                listener.OnTargetClicked -= OnTargetClicked;    
            }
        }

        private void OnTargetClicked(EntityConfig entity)
        {
            Debug.Log($"Player turn. {entity.Name} targeted");
            if (entity.IsDead || entity.Team == _currentEntity.Value.Team)
                return;
            if (_currentEntity.Value.SkipAttackTargeting)
            {
                _currentEntity.Value.SkipAttackTargeting = false;
                _eventBus.RaiseEvent(new AttackEvent(_currentEntity.Value, _attackedEntity.Value));
                Debug.Log($"{_currentEntity.Value.Name} attack {_attackedEntity.Value.Name}");
            }
            else
            {
                _eventBus.RaiseEvent(new AttackEvent(_currentEntity.Value, entity));
                _attackedEntity.Value = entity;
                Debug.Log($"{_currentEntity.Value.Name} attack {entity.Name}");    
            }
            Finish();
        }
    }
}
