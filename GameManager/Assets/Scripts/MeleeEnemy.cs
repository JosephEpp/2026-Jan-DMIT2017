using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Attack Info")]
    public SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color attackColor;

    public override void Attack()
    {
        StartCoroutine(AttackAnimation());
    }

    public override void Die()
    {
        
    }

    private IEnumerator AttackAnimation()
    {
        spriteRenderer.color = attackColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = defaultColor;
    }
}
