using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimpleProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1.0f;
    public float duration = 1.0f;
    public int dmg;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void InstantiateProjectile(Vector2 velocity, int ATK_)
    {
        rb.linearVelocity = velocity * speed;
        StartCoroutine(ProjectileTimer());
        dmg = ATK_;
    }

    public IEnumerator ProjectileTimer()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCombatController>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
