using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace MenuScripts
{
    public class MenuManager : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private TextMeshProUGUI tmp;
        
        [SerializeField]
        private GameObject wood;


        public void OnPointerDown(PointerEventData eventData)
        {
            BrokeTheWood();
            Destroy(tmp);
        
            DOVirtual.DelayedCall(1f, () =>
            {   
                SceneManager.LoadScene("GameScene");
            });
            
            Destroy(gameObject);
        }
    
        void BrokeTheWood()
        {
            GameObject brokenWood = wood.transform.GetChild(0).gameObject;
            wood.transform.DetachChildren();
            Destroy(wood);
            brokenWood.SetActive(true);
        }
        
    }
}
