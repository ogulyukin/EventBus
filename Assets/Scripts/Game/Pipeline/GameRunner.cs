using Game.Pipeline.Turn;
using Game.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Pipeline
{
    public sealed class GameRunner : MonoBehaviour
    {
        [SerializeField] private bool runOnFinish = true;
        [SerializeField] private CanvasView menuCanvasView;
        [SerializeField] private CanvasView gameCanvasView;
        [SerializeField] private StartGameButtonListener startGameButtonListener;
        [SerializeField] private ExitGameButtonListener exitGameButtonListener;
        [SerializeField] private ExitGameButtonListener inGameExitButtonListener;

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
            ViewMenu();
        }

        private void ViewMenu()
        {
            gameCanvasView.SetActive(false);
            menuCanvasView.SetActive(true);
        }

        private void OnEnable()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
            startGameButtonListener.AddListener(Run);
            exitGameButtonListener.AddListener(Exit);
            inGameExitButtonListener.AddListener(Exit);
        }

        private void OnDisable()
        {
            _turnPipeline.OnFinished -= OnTurnPipelineFinished;
            startGameButtonListener.RemoveListener(Run);
            exitGameButtonListener.RemoveListener(Exit);
            inGameExitButtonListener.RemoveListener(Exit);
        }

        [Button]
        private void Run()
        {
            gameCanvasView.SetActive(true);
            menuCanvasView.SetActive(false);
            runOnFinish = true;
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if(runOnFinish) {Run();}else{ViewMenu();}
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
