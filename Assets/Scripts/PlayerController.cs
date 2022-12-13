using Murdock.Audio;
using Murdock.GM;
using UnityEngine;

namespace Murdock.Core
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public float liftingForce = 5f;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.isDead) return;

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_rigidbody.isKinematic)
                {
                    _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    GameManager.Instance.StartGame();
                }

                Jump();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle") && !GameManager.Instance.isDead)
            {
                AudioManager.Instance.PlayHitSfx();
                GameManager.Instance.GameOver();
            }
        }

        void Jump()
        {
            AudioManager.Instance.PlayJumpingSfx();
            _rigidbody.AddForce(Vector2.up * liftingForce, ForceMode2D.Impulse);
        }

        public void ResetPosition()
        {
            transform.position = Vector3.zero;
        }
    }
}