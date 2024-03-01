using UnityEngine;

namespace UI
{
    public class VfxView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem system;

        public void Play()
        {
            system.Play();
        }
    }
}
