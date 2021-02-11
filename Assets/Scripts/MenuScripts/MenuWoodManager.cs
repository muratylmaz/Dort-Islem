using System;
using UnityEngine;

namespace MenuScripts
{
    public class MenuWoodManager : MonoBehaviour
    {

        private float woodVelocity = -100;

        void Update()
        {
            transform.Rotate( 0 , 0 , 1 * woodVelocity * Time.deltaTime );
        }
    }
}
