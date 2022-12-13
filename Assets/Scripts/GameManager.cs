using System;
using System.Collections.Generic;
using Murdock.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Murdock.GM
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Spawner spawner;
        public bool isDead;
        public int score;

        [Header("User Interface")] [SerializeField]
        private GameObject startInstruction;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private Image scoreImg;
        [SerializeField] private List<Sprite> scoreImgList;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void StartGame()
        {
            spawner.StartSpawnPipes();
            startInstruction.SetActive(false);
            scoreImg.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            Debug.Log("Game over!");
            isDead = true;
            spawner.CancelSpawnPipes();
            gameOver.SetActive(true);
        }

        public void IncreaseScore()
        {
            score++;
        }

        public void ResetGame()
        {
            score = 0;
            isDead = false;
            playerController.ResetPosition();
            startInstruction.SetActive(true);
            scoreImg.gameObject.SetActive(false);
        }
    }
}