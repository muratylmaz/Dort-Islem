using UnityEngine;
using UnityEngine.EventSystems;

namespace GameScripts
{
    public class InputManager :  MonoBehaviour, IPointerDownHandler
    {
        private GameObject arrow;

        public GameObject Arrow
        {
            get => arrow;
            set => arrow = value;
        }

        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(arrow != null)
                arrow.gameObject.GetComponent<ArrowManager>().ThrowTheArrow();
        }
    }
}
