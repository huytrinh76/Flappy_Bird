using DG.Tweening;
using Murdock.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Murdock.GM
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private Spawner spawner;
        public bool isDead;
        public int score;

        [Header("User Interface")] [SerializeField]
        private GameObject startInstruction;

        [SerializeField] private GameObject gameOver;
        [SerializeField] private Text scoreText;
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            restartButton.onClick.AddListener(ResetGame);
        }

        public void StartGame()
        {
            spawner.StartSpawnPipes();
            startInstruction.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            Debug.Log("Game over!");
            isDead = true;
            spawner.CancelSpawnPipes();
            gameOver.SetActive(true);
            gameOver.transform.localScale = Vector3.zero;
            gameOver.transform.DOScale(Vector3.one, 1f);
            restartButton.gameObject.SetActive(true);
            Image restartImg = restartButton.GetComponent<Image>();
            restartImg.fillAmount = 0;
            restartImg.DOFillAmount(1, 0.5f);
        }

        public void IncreaseScore()
        {
            score++;
            scoreText.text = "" + score;
        }

        private void ResetGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}