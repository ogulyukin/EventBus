namespace Game.HeroesAbilities
{
    public abstract class BaseAbility
    { 
        public abstract void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage);
    }
}
