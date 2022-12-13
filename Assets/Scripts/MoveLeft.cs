using Murdock.GM;
using UnityEngine;

namespace Murdock.Core
{
    public class MoveLeft : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        public float speed = 0.05f;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.isDead) return;

            Vector2 offset = _meshRenderer.material.mainTextureOffset;
            if (offset.x > 1)
            {
                offset.x = 0;
            }

            offset += Vector2.right * (speed * Time.deltaTime);
            _meshRenderer.material.mainTextureOffset = offset;
        }
    }
}