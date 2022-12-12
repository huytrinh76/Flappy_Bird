using UnityEngine;

namespace Murdock.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        private AudioSource _audioSource;

        [SerializeField] private AudioClip jumpingSfx;
        [SerializeField] private AudioClip hitSfx;
        [SerializeField] private AudioClip deathSfx;
        [SerializeField] private AudioClip pointSfx;
        [SerializeField] private AudioClip swooshSfx;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayJumpingSfx()
        {
            _audioSource.PlayOneShot(jumpingSfx);
        }

        public void PlayHitSfx()
        {
            _audioSource.PlayOneShot(hitSfx);
        }
        
        public void PlayDeathSfx()
        {
            _audioSource.PlayOneShot(deathSfx);
        }
        
        public void PlayScoreSfx()
        {
            _audioSource.PlayOneShot(pointSfx);
        }
        
        public void PlaySwooshSfx()
        {
            _audioSource.PlayOneShot(swooshSfx);
        }
    }
}