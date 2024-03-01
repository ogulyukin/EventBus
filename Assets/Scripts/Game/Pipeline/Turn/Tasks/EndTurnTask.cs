using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class EndTurnTask : PipelineTask
    {
        private readonly EntityStorage _entityStorage;
        private readonly TurnPipelineRunner _turnPipelineRunner;

        public EndTurnTask(EntityStorage entityStorage, TurnPipelineRunner turnPipelineRunner)
        {
            _entityStorage = entityStorage;
            _turnPipelineRunner = turnPipelineRunner;
        }

        protected override void OnRun()
        {
            Debug.Log("Turn Ended");
            if (!_entityStorage.HasAliveHeroes(true) || !_entityStorage.HasAliveHeroes(false))
            {
                _turnPipelineRunner.StopTurnPipeline();
                Debug.Log("Game Over!!!");
            }
            Finish();
        }
    }
}
