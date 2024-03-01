using System;
using Game.Pipeline.Turn;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Pipeline
{
    public class TurnPipelineRunner : MonoBehaviour
    {
        [SerializeField] private bool runOnStart = true;
        [SerializeField] private bool runOnFinish = true;
        
        private TurnPipeline _turnPipeline;

        [Inject]
        private void Construct(TurnPipeline pipeline)
        {
            _turnPipeline = pipeline;
        }

        public void StopTurnPipeline()
        {
            runOnFinish = false;
        }

        private void Start()
        {
            if(runOnStart) Run();
        }

        private void OnEnable()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
        }

        private void OnDisable()
        {
            _turnPipeline.OnFinished -= OnTurnPipelineFinished;
        }

        [Button]
        private void Run()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if(runOnFinish) Run();
        }
    }
}
