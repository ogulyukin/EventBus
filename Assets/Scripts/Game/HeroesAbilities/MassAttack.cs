using System.Collections.Generic;
using Game.Events;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Game.HeroesAbilities
{
    [UsedImplicitly]
    public sealed class MassAttack : BaseAbility
    {
        [ShowInInspector] private int _damage = 1;
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(currentEntity.Value.IsDead) return;
            
            var enemyTeam = new List<EntityConfig>();
            
            enemyTeam.AddRange(entityStorage.GetTeam(!attackedEntity.Value.Team)); 
    
            for(var i = 0; i < enemyTeam.Count; i++)
            {
                if (!enemyTeam[i].IsDead)
                {
                    eventBus.RaiseEvent(new ExtraAttackEvent(attackedEntity.Value, enemyTeam[i], _damage));        
                }
            }
        }
    }
}
