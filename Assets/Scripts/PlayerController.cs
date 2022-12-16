using Murdock.Audio;
using Murdock.GM;
using UnityEngine;

namespace Murdock.Core
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public float liftingForce = 5f;

        public float strength = 5f;
        public float gravity = -9.81f;
        public float tilt = 5f;

        private Vector3 _direction;
        private bool _startGame;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.isDead) return;

            KinematicJump();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Obstacle") && !GameManager.Instance.isDead)
            {
                AudioManager.Instance.PlayHitSfx();
                GameManager.Instance.GameOver();
            }
        }

        // My solution
        void DynamicJump()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_rigidbody.isKinematic)
                {
                    _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                    GameManager.Instance.StartGame();
                }
            
                AudioManager.Instance.PlayJumpingSfx();
                _rigidbody.AddForce(Vector2.up * liftingForce, ForceMode2D.Impulse);
            }
        }

        // Better solution
        void KinematicJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                AudioManager.Instance.PlayJumpingSfx();
                _direction = Vector3.up * strength;

                if (!_startGame)
                {
                    _startGame = true;
                    GameManager.Instance.StartGame();
                }
            }

            if (_startGame)
            {
                // Apply gravity and update the position
                _direction.y += gravity * Time.deltaTime;
                transform.position += _direction * Time.deltaTime;

                // Tilt the bird based on the direction
                Vector3 rotation = transform.eulerAngles;
                rotation.z = _direction.y * tilt;
                transform.eulerAngles = rotation;
            }
        }

        public void ResetPosition()
        {
            transform.position = Vector3.zero;
        }
    }
}