using UnityEngine;

namespace Murdock.Core
{
    public class FrameRateLock : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}