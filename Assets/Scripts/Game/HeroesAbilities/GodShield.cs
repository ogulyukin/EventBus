using Game.Events;
using JetBrains.Annotations;

namespace Game.HeroesAbilities
{
    [UsedImplicitly]
    public sealed class GodShield : BaseAbility
    {
        private bool _isUsed;
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(_isUsed) return;
            eventBus.RaiseEvent(new HealEvent(attackedEntity.Value, currentEntity.Value.Damage));
            _isUsed = true;
        }
    }
}
