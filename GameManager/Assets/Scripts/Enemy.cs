using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    public int HP;
    public int ATK;
    public int DEF;
    public CircleOverlap sightline;
    public CircleOverlap attackRange;
    public float attackDelay;
    public Vector2 playerPosition;
    private Coroutine attackCoroutine;
    private void Awake()
    {
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
    }
    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

    public void Patrol()
    {

    }
    public abstract void Attack();
    public abstract void TakeDamage();
    public abstract void Die();

    public abstract void Pursue();

    private void Update()
    {
        if (sightline.OverlapCheck())
        {
            Pursue();
        }

        if (attackRange.OverlapCheck())
        {
            StartAttackCoroutine();
        }
    }

    [ContextMenu("Attack")]
    public void StartAttackCoroutine()
    {
        if (attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());

    }
    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        yield return null;
        attackCoroutine = null;
    }


}
