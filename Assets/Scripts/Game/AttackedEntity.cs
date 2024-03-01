using JetBrains.Annotations;

namespace Game
{
    [UsedImplicitly]
    public sealed class AttackedEntity
    {
        public EntityConfig Value { get; set; }
        
        public AttackedEntity()
        {
            Value = null;
        }
    }
}
