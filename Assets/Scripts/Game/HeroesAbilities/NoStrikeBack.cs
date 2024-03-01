using Game.Events;
using JetBrains.Annotations;

namespace Game.HeroesAbilities
{
    [UsedImplicitly]
    public class NoStrikeBack : BaseAbility
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            eventBus.RaiseEvent(new DisableStrikeBackEvent(attackedEntity.Value));
        }
    }
}
