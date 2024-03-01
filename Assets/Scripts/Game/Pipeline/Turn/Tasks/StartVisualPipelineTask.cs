using Game.Pipeline.Visual;
using JetBrains.Annotations;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class StartVisualPipelineTask : PipelineTask
    {
        private readonly VisualPipeline _visualPipeline;

        public StartVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnVisualPipelineFinished;
        }

        private void OnVisualPipelineFinished()
        {
            _visualPipeline.Clear();
            Finish();
        }
    }
}
