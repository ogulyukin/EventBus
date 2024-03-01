using Game;
using Game.Handlers.Turn;
using Game.Handlers.Visual;
using Game.Pipeline;
using Game.Pipeline.Turn;
using Game.Pipeline.Turn.Tasks;
using Game.Pipeline.Visual;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private TurnPipelineRunner turnPipelineRunner;
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
            Container.Bind<TurnPipelineRunner>().FromInstance(turnPipelineRunner);
            
            //Register Handlers
            Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExtraAttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DisableStrikeBackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SkipTurnHandler>().AsSingle();

            //Complex Tasks
            Container.Bind<StartTurnTask>().AsSingle().NonLazy();
            Container.Bind<PlayerTurnTask>().AsSingle().NonLazy();
            Container.Bind<StartGameTask>().AsSingle().NonLazy();
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
            Container.BindInterfacesAndSelfTo<RedrawStatsVisualHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ActivateEntityVisualHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DeactivateEntityVisualHandler>().AsSingle().NonLazy();
            
            //Complex Tasks
            Container.Bind<StartVisualPipelineTask>().AsSingle();
        }
    }
}