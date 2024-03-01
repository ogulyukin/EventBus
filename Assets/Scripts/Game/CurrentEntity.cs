using JetBrains.Annotations;

namespace Game
{
    [UsedImplicitly]
    public sealed class CurrentEntity
    {
        public EntityConfig Value { get; set; }
        
        public CurrentEntity()
        {
            Value = null;
        }
    }
}
