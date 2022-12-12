using UnityEngine;

namespace Murdock.Core
{
    public class PipeController : MonoBehaviour
    {
        public float speed = 5f;
        private float _boundary;

        // Start is called before the first frame update
        void Start()
        {
            _boundary = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerController.Instance.isDead) return;
            if (transform.position.x < _boundary)
            {
                gameObject.SetActive(false);
            }

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}