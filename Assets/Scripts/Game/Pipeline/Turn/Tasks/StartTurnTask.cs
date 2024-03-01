using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class StartTurnTask : PipelineTask
    {
        private int _turnCount;
        private readonly EventBus _eventBus;

        public StartTurnTask(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _turnCount++;
            _eventBus.RaiseEvent(new StartTurnEvent(_turnCount));
            Debug.Log($"Turn {_turnCount} started!");
            Finish();
        }
    }
}
