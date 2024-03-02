using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource startTurnClip;
        [SerializeField] private AudioSource lowHealthClip;
        [SerializeField] private AudioSource abilityClip;
        [SerializeField] private AudioSource deathClip;
        public async Task PlayStatTurn()
        {
            await PlaySound(startTurnClip);
        }
        
        public async Task PlayLowHealth()
        {
            await PlaySound(lowHealthClip);
        }
        
        public async Task PlayAbility()
        {
            await PlaySound(abilityClip);
        }
        
        public async Task PlayDeath()
        {
            await PlaySound(deathClip);
        }

        private async Task PlaySound(AudioSource source)
        {
            source.Play();
            if(source.clip == null)
                return;
            await Task.Delay(TimeSpan.FromSeconds(source.clip.length));
        }
    }
}
