using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndScript
{
    public class EndScript : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreTMP, bestScoreTMP;
        [SerializeField]
        private AudioClip tadaSound;
        
        void Start()
        {
            AudioManager.Play(GetComponent<AudioSource>(), tadaSound);
            transform.DOLocalMove(new Vector3(0, 810, 0), 0.4f).OnComplete(Shake);
            scoreTMP.text = "Skor = " + PlayerPrefs.GetInt("Score");
            
            if (PlayerPrefs.HasKey("BestScore"))
            {
                if (PlayerPrefs.GetInt("BestScore") > PlayerPrefs.GetInt("Score"))
                {
                    bestScoreTMP.text = "En Yüksek\nSkor = " + PlayerPrefs.GetInt("BestScore");
                }
                else
                {
                    bestScoreTMP.text = "En Yüksek\nSkor = " + PlayerPrefs.GetInt("Score");
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("Score"));
                bestScoreTMP.text = "En Yüksek\nSkor = " + PlayerPrefs.GetInt("BestScore");
            }
            PlayerPrefs.Save();
        }

        void Shake()
        {
            transform.DOShakeRotation(1, 1).SetEase(Ease.OutBounce);
        }

        public void TryAgain()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
