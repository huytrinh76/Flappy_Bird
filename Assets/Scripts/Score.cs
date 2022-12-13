using Murdock.Audio;
using Murdock.GM;
using UnityEngine;

namespace Murdock.Core
{
    public class Score : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.PlayScoreSfx();
                GameManager.Instance.IncreaseScore();
            }
        }
    }
}