using DG.Tweening;
using QuestionsScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] 
        private GameObject woodPrefab, arrowPrefab, woodenSign, upperPanel;
        [SerializeField]
        private ParticleSystem particleSys;
        [SerializeField]
        private TextMeshProUGUI arrowTMP, scoreTMP;
        private int arrowCount;
        private int currentArrowCount;
        private int score;
        private GameObject currentWood, currentArrow;
        private bool gameActive = true;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            CreateNewWood();
        }

        public int ArrowCount
        {
            get => arrowCount;
            set => arrowCount = value;
        }

        public int CurrentArrowCount => currentArrowCount;

        public int Score => score;

        public bool IsGameActive
        {
            get => gameActive;
            set => gameActive = value;
        }

        public void CreateNewWood()
        {
            if (IsGameActive)
            {
                currentWood = Instantiate(woodPrefab, new Vector3(0, 1f, 0), Quaternion.identity);
                woodenSign.GetComponent<WoodenSignManager>().OpenSign();
            }

        }

        public void CreateNewArrow()
        {
            if (IsGameActive)
            {
                currentArrow = Instantiate(arrowPrefab, new Vector3(0, -3.5f, 0), Quaternion.identity);
                InputManager.Instance.Arrow = currentArrow;
            }
        }

        public void PlayParticles()
        {
            particleSys.Play();
        }

        public void StopTheGame()
        {
            IsGameActive = false;
            currentWood.transform.DOScale(Vector3.zero, 0.5f);
            currentArrow.GetComponent<Rigidbody2D>().gravityScale = 5;
            currentArrow.transform.DOLocalRotate(new Vector3(0, 0, 180), 2);
            upperPanel.GetComponent<UpperPanelManager>().CloseUpperPanel();
            PlayerPrefs.SetInt("Score", score);
            DOVirtual.DelayedCall(1.0f, () => SceneManager.LoadScene("EndScene"));
        }

        public void ShowArrowsAsGray()
        {
            arrowTMP.text = arrowCount.ToString();
            upperPanel.GetComponent<UpperPanelManager>().ShowArrowsAsGray(arrowCount);
        }

        public void ShowArrowColorful()
        {
            upperPanel.GetComponent<UpperPanelManager>().ShowArrowColorful(currentArrowCount);
            currentArrowCount++;
        }

        public void CloseAnArrow()
        {
            currentArrowCount--;
            upperPanel.GetComponent<UpperPanelManager>().CloseAnArrow(currentArrowCount);
            arrowTMP.text = currentArrowCount.ToString();
        }

        public void IncreaseScore(int number)
        {
            score += number;
            scoreTMP.text = score.ToString();
        }

        public void DecreaseScore(int number)
        {
            score -= number;
            scoreTMP.text = score.ToString();
        }
    }
}
