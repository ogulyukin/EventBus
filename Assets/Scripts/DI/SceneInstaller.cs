using Game;
using Game.Handlers.Turn;
using Game.Handlers.Visual;
using Game.Pipeline;
using Game.Pipeline.Turn;
using Game.Pipeline.Turn.Tasks;
using Game.Pipeline.Visual;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DI
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [FormerlySerializedAs("turnPipelineRunner")] [SerializeField] private GameRunner gameRunner;
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<CurrentEntity>().AsSingle();
            Container.Bind<AttackedEntity>().AsSingle();
            Container.Bind<EntityButtonListener>().FromComponentsInHierarchy().AsTransient();
            Container.Bind<HeroListView>().FromComponentsInHierarchy().AsTransient();
            Container.Bind<EntityStorage>().AsSingle();
            ConfigureTurn();
            ConfigureVisual();
        }

        private void ConfigureTurn()
        {
            Container.Bind<TurnPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
            Container.Bind<GameRunner>().FromInstance(gameRunner);
            
            //Register Handlers
            Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExtraAttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DisableStrikeBackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SkipTurnHandler>().AsSingle();

            //Complex Tasks
            Container.Bind<StartTurnTask>().AsSingle();
            Container.Bind<PlayerTurnTask>().AsSingle();
            Container.Bind<StartGameTask>().AsSingle();
            Container.Bind<StrikeBackTask>().AsSingle();
            Container.Bind<EndTurnAbilityTask>().AsSingle();
            Container.Bind<AfterStrikeBackAbilityTask>().AsSingle();
            Container.Bind<BeforeAttackAbilityTask>().AsSingle();
            Container.Bind<AfterAttackAbilityTask>().AsSingle();
            Container.Bind<GlobalAbilityTask>().AsSingle();
            Container.Bind<EndTurnTask>().AsSingle();
            Container.Bind<SwitchHeroTask>().AsSingle();
        }

        private void ConfigureVisual()
        {
            Container.Bind<VisualPipeline>().AsSingle();
            
            //Register Handlers
            Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExtraAttackVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RedrawStatsVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivateEntityVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeactivateEntityVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartTurnVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchHeroVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityUsedVisualHandler>().AsSingle();
            
            //Complex Tasks
            Container.Bind<StartVisualPipelineTask>().AsSingle();
        }
    }
}