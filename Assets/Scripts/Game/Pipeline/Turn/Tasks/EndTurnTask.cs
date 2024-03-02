using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class EndTurnTask : PipelineTask
    {
        private readonly EntityStorage _entityStorage;
        private readonly GameRunner _gameRunner;
        private readonly StartGameTask _startGameTask;

        public EndTurnTask(EntityStorage entityStorage, GameRunner gameRunner, StartGameTask startGameTask)
        {
            _entityStorage = entityStorage;
            _gameRunner = gameRunner;
            _startGameTask = startGameTask;
        }

        protected override void OnRun()
        {
            if (!_entityStorage.HasAliveHeroes(true) || !_entityStorage.HasAliveHeroes(false))
            {
                _gameRunner.StopTurnPipeline();
                _startGameTask.ResetGameStart();
            }
            Finish();
        }
    }
}
