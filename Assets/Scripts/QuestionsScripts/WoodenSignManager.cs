using System.Collections;
using DG.Tweening;
using GameScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestionsScripts
{
    public class WoodenSignManager : MonoBehaviour
    {   
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        public TextMeshProUGUI questionTMP;
        [SerializeField]
        public TextMeshProUGUI[] answers;
        [SerializeField]
        public GameObject correctImage,wrongImage;
        [SerializeField]
        public AudioClip correctSound, wrongSound;
        private GameManager gameManager;
        private OperationBase currentOperation;
        private int currentAnswer;
        private bool busy;
    
        private OperationBase[] operations =
        {
            new Addition(),
            new Extraction(),
            new Multiplication(),
            new Division()
        };
        
        private void Start()
        {
            gameManager = GameManager.Instance;
            audioSource = GetComponent<AudioSource>();
            OpenSign();
        }
    
        public void OpenSign()
        {
            transform.DOLocalMove(new Vector3(0, -415, 0), 0.5f).SetEase(Ease.OutBack).OnComplete(IncreaseSize);
            GetNewQuestion();
            busy = false;
        }

        private void CloseSign()
        {
            transform.DOLocalMove(new Vector3(0, -1055, 0), 0.5f).SetEase(Ease.InBack);
        }
    
        private void GetNewQuestion()
        {
            currentOperation = operations[Random.Range(0, operations.Length)].MakeTheOperation();
            FillTheSign();
        }
    
        private void FillTheSign()
        {
            questionTMP.text = currentOperation.GetQuestion();

            currentAnswer = currentOperation.GetAnswer();
            int randomNumber = Random.Range(0, answers.Length);
            answers[randomNumber].text = currentAnswer.ToString();
            ArrayList numbers = new ArrayList();
            numbers.Add(currentAnswer);

            for (int i = 0; i < answers.Length; i++)
            {
                if (i == randomNumber)
                {
                    continue;
                }
                else
                {
                    int wrongRandomNumber;
                    while (true)
                    {
                        wrongRandomNumber = Random.Range(currentAnswer - 10, currentAnswer + 11);
                        if (!numbers.Contains(wrongRandomNumber) && wrongRandomNumber >= 0)
                        {
                            break;
                        }
                    }
                    numbers.Add(wrongRandomNumber);
                    answers[i].text = wrongRandomNumber.ToString();
                }
            }
        }
    
        private void IncreaseSize()
        {
            questionTMP.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            }
        }
    
        private void SizeReduction()
        {
            questionTMP.transform.DOScale(Vector3.zero, 0.5f);
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i].transform.DOScale(Vector3.zero, 0.5f);
            }
        }
    
        public void ButtonEvent(TextMeshProUGUI answer)
        {
            if (!busy)
            {
                busy = true;
                if (CheckAnswer(answer.text))
                {
                    AudioManager.Play(audioSource, correctSound);
                    correctImage.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnComplete(
                        () => correctImage.transform.DOScale(Vector3.zero, 0.5f));
                    gameManager.IncreaseScore(currentAnswer);
                    gameManager.ShowArrowColorful();
                    SizeReduction();
                    if (gameManager.CurrentArrowCount == gameManager.ArrowCount)
                    {
                        CloseSign();
                        gameManager.CreateNewArrow();
                    }
                    else
                    {
                        GoToNextQuestion();
                    }
                }
                else
                {
                    AudioManager.Play(audioSource, wrongSound);
                    wrongImage.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnComplete(
                        ()=> wrongImage.transform.DOScale(Vector3.zero, 0.5f));
                    if (gameManager.Score - currentAnswer > 0)
                    {
                        gameManager.DecreaseScore(currentAnswer);
                    }
                    else
                    {
                        gameManager.DecreaseScore(gameManager.Score);
                    }
                    SizeReduction();
                    GoToNextQuestion();
                }
            }
        }

        private void GoToNextQuestion()
        {
            DOVirtual.DelayedCall(0.5f, () =>
            {
                GetNewQuestion();
                IncreaseSize();
                busy = false;
            });
        }
    
        private bool CheckAnswer(string numberOnButton)
        {
            if (currentAnswer.ToString() == numberOnButton)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
