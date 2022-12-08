using UnityEngine;

namespace Murdock.Core
{
    public class RepeatEnvironment : MonoBehaviour
    {
        private Vector3 _startPos;

        private float _repeatWidth;

        // Start is called before the first frame update
        void Start()
        {
            _startPos = transform.position;
            _repeatWidth = GetComponent<SpriteRenderer>().size.x / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < _startPos.x - _repeatWidth)
            {
                transform.position = _startPos;
            }
        }
    }
}