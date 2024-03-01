using System;
using Game.Pipeline.Turn;
using Game.Pipeline.Turn.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace Game.Pipeline
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller: IInitializable, IDisposable
    {
        private readonly TurnPipeline _pipeline;

        private readonly DiContainer _container;

        public TurnPipelineInstaller(DiContainer container, TurnPipeline pipeline)
        {
            _container = container;
            _pipeline = pipeline;
        }

        public void Initialize()
        {
            _pipeline.AddTask(_container.Resolve<StartGameTask>());
            _pipeline.AddTask(_container.Resolve<StartTurnTask>());
            _pipeline.AddTask(_container.Resolve<BeforeAttackAbilityTask>());
            _pipeline.AddTask(_container.Resolve<PlayerTurnTask>());
            _pipeline.AddTask(_container.Resolve<AfterAttackAbilityTask>());
            _pipeline.AddTask(_container.Resolve<StrikeBackTask>());
            _pipeline.AddTask(_container.Resolve<EndTurnAbilityTask>());
            _pipeline.AddTask(_container.Resolve<AfterStrikeBackAbilityTask>());
            _pipeline.AddTask(_container.Resolve<GlobalAbilityTask>());
            _pipeline.AddTask(_container.Resolve<SwitchHeroTask>());
            _pipeline.AddTask(_container.Resolve<StartVisualPipelineTask>());
            _pipeline.AddTask(_container.Resolve<EndTurnTask>());
        }

        public void Dispose()
        {
            _pipeline.Clear();
        }
    }
}
