using GameScripts;
using UnityEngine;

namespace MenuScripts
{
    public class MenuBrokenWoodManager : MonoBehaviour
    {
        private float explosionForce = 300f;
        
        [SerializeField]
        private AudioClip choppingWoodSound;
    
        private void OnTriggerEnter2D(Collider2D other)
        { 
            AudioManager.Play(GetComponent<AudioSource>(), choppingWoodSound);

            VibrationManager.Vibrate();
            
            if (other.gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
            {
                rigidbody2D.AddExplosionForce(explosionForce, transform.position);
            }
        }
    }
}
