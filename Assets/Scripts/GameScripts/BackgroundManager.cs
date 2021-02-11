using UnityEngine;

namespace GameScripts
{
    public class BackgroundManager : MonoBehaviour
    {
        private float speed = 0.5f;

        private Renderer render;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            render = GetComponent<Renderer>();
        }

        void FixedUpdate()
        {
            Vector2 offset = new Vector2(Time.time * speed, 0f);
            render.material.mainTextureOffset = offset;
        }
    }
}
