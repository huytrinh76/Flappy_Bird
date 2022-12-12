using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdock.GM
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int score;

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
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}