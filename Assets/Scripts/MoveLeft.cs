using UnityEngine;

namespace Murdock.Core
{
    public class MoveLeft : MonoBehaviour
    {
        public float speed = -1f;

        // Update is called once per frame
        void Update()
        {
            if (!PlayerController.Instance.isDead)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}