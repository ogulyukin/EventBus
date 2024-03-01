using Game.Events;
using JetBrains.Annotations;

namespace Game.HeroesAbilities
{
    [UsedImplicitly]
    public sealed class FrozeEnemy : BaseAbility
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            eventBus.RaiseEvent(new SkipTurnEvent(attackedEntity.Value));
        }
    }
}
