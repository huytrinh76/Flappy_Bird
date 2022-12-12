using Murdock.Audio;
using UnityEngine;

namespace Murdock.Core
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        private Rigidbody2D _rigidbody;
        public float liftingForce = 5f;
        public bool isDead;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isDead)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    if (_rigidbody.isKinematic)
                    {
                        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    }

                    Jump();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle"))
            {
                isDead = true;
                AudioManager.Instance.PlayHitSfx();
                Debug.Log("Game over!");
            }
        }

        void Jump()
        {
            AudioManager.Instance.PlayJumpingSfx();
            _rigidbody.AddForce(Vector2.up * liftingForce, ForceMode2D.Impulse);
        }
    }
}