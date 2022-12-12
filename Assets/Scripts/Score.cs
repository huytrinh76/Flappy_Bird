using System;
using Murdock.Audio;
using Murdock.GM;
using UnityEngine;

namespace Murdock.Core
{
    public class Score : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.composite.CompareTag("Player"))
            {
                AudioManager.Instance.PlayScoreSfx();
                GameManager.Instance.score++;
            }
        }
    }
}