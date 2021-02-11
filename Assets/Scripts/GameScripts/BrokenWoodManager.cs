using DG.Tweening;
using UnityEngine;

namespace GameScripts
{
    public class BrokenWoodManager : MonoBehaviour
    {
        private float explosionForce = 500f;
        [SerializeField]
        private AudioClip choppingWoodSound;
        
        void Start() 
        {
            AudioManager.Play(GetComponent<AudioSource>(), choppingWoodSound);

            VibrationManager.Vibrate();
            
            DOVirtual.DelayedCall(0.5f, DestroyMethod);
        }

        void DestroyMethod()
        {
            GameManager.Instance.CreateNewWood();
        
            DOVirtual.DelayedCall(0.5f, () =>
            {
                Destroy(gameObject);
            });
        
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
            {
                rigidbody2D.AddExplosionForce(explosionForce, transform.position);
            }
        }
    }
}
