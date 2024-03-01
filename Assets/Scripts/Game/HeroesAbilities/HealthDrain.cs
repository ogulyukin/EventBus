using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.HeroesAbilities
{
    [UsedImplicitly]
    public sealed class HealthDrain : BaseAbility
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            var randomResult = Random.Range(0, 99);
            if ( randomResult >= 50)
            {
                eventBus.RaiseEvent(new HealEvent(currentEntity.Value, currentEntity.Value.Damage));
            }
        }
    }
}
