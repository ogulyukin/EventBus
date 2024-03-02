using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public class StartGameButtonListener : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        public void AddListener(UnityAction action)
        {
            startButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            startButton.onClick.RemoveListener(action);
        }
    }
}
