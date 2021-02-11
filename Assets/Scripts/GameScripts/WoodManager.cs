using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace GameScripts
{
    public class WoodManager : MonoBehaviour
    {
        [SerializeField]
        private float woodVelocity;
        private int currentArrowsCount;
        private GameManager gameManager;

        private void Awake()
        {
            transform.localScale = Vector3.zero;
            GetComponent<CircleCollider2D>().enabled = false;
        }

        void Start()
        {
            gameManager = GameManager.Instance;
            gameManager.ArrowCount = Random.Range(3, 11);
            gameManager.ShowArrowsAsGray();
            transform.DOScale(new Vector3(0.4f, 0.4f, 1f), 0.5f).OnComplete(() =>
            {
                GetComponent<CircleCollider2D>().enabled = true;
            });
        }

        void Update()
        {
            transform.Rotate( 0 , 0 , 1 * woodVelocity * Time.deltaTime );
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (gameManager.IsGameActive)
            {
                other.transform.parent = transform;
                Destroy(other.gameObject.GetComponent<Rigidbody2D>());
                gameManager.PlayParticles();
                transform.DOShakePosition(0.1f, 0.1f);
                gameManager.CloseAnArrow();
                currentArrowsCount++;
                if (!AnyArrow())
                {
                    BrokeTheWood();
                    return;
                }
                gameManager.CreateNewArrow();
            }
        }
        
        bool AnyArrow()
        {
            if (currentArrowsCount == gameManager.ArrowCount)
            {
                return false;
            }
            return true;
        }
    
        void BrokeTheWood()
        {
            GameObject brokenWood = transform.GetChild(0).gameObject;
            transform.DetachChildren();
            Destroy(gameObject);
            brokenWood.SetActive(true);
        }
    }
}
