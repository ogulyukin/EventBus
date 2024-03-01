using UnityEngine;

namespace Game.Events
{
    public class DeactivateEntityEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public DeactivateEntityEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
