using UnityEngine;

namespace Game.UI
{
    public class CanvasView : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        
        public void SetActive(bool flag)
        {
            canvas.SetActive(flag);
        }
    }
}
