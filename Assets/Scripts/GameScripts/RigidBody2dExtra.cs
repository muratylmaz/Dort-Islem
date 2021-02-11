using UnityEngine;

namespace GameScripts
{
    public static class RigidBody2dExtra
    {
        public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition)
        {
            Vector2 explosionDir = rb.position - explosionPosition;
            rb.AddForce( explosionDir * explosionForce, ForceMode2D.Force);
        }
    }
}
