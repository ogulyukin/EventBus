using UnityEngine;

namespace Game.Pipeline.Visual.Tasks
{
    public class DestroyVisualTask : PipelineTask
    {
        private readonly EntityConfig _targetEntity;

        public DestroyVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.View.gameObject.SetActive(false);
            _targetEntity.IsDead = true;
            Finish();
        }
    }
}
