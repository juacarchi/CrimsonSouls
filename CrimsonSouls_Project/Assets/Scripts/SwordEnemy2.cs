using UnityEngine;

public class SwordEnemy2 : MonoBehaviour
{
    public Enemy2 e2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            CollisionManager.instance.DamageToPlayer(e2.damage);
        }
    }
}
