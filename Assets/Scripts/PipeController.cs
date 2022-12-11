using UnityEngine;

namespace Murdock.Core
{
    public class PipeController : MonoBehaviour
    {
        public float speed = 5f;
        private float _boundary = -9f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < _boundary)
            {
                gameObject.SetActive(false);
            }

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}