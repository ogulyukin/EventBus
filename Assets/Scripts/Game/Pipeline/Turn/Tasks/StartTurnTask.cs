using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class StartTurnTask : PipelineTask
    {
        protected override void OnRun()
        {
            Debug.Log("Turn started!");

            Finish();
        }
    }
}
