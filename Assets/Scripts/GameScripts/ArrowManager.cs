using DG.Tweening;
using UnityEngine;

namespace GameScripts
{
    public class ArrowManager : MonoBehaviour
    {
        [SerializeField] 
        private float arrowVelocity;
        [SerializeField]
        private AudioClip[] clips;
        [SerializeField]
        private AudioClip arrowThrowSound, arrowCollisionSound;
        private bool ready;
        private Rigidbody2D arrowRigid;

        void Start()
        {
            ready = true;
            InputManager.Instance.Arrow = gameObject;
            arrowRigid = GetComponent<Rigidbody2D>();
            GetComponent<SpriteRenderer>().DOFade(1, 0.25f);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            ready = false;

            if (other.gameObject.CompareTag("Wood"))
            {
                AudioManager.Play(GetComponent<AudioSource>(), clips[Random.Range(0, clips.Length)]);
            }
            
            if (other.gameObject.CompareTag("Arrow"))
            {
                AudioManager.Play(GetComponent<AudioSource>(), arrowCollisionSound);
                GameManager.Instance.StopTheGame();
            }

            if (other.gameObject.CompareTag("BrokenWood"))
            {
                transform.parent = other.transform;
            }
        }
        
        public void ThrowTheArrow()
        {
            if (ready)
            {
                AudioManager.Play(GetComponent<AudioSource>(), arrowThrowSound);
                arrowRigid.velocity = Vector2.up * arrowVelocity;
            }
        }
    }
}