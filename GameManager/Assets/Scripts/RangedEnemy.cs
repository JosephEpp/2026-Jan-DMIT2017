using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectile;
    public GameObject projectileSpawnPoint;

    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        GameObject obj = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
        obj.GetComponent<SimpleProjectile>().InstantiateProjectile(new Vector2(0, -1));
    }

    [ContextMenu("Attack")]
    public void StartAttackCoroutine()
    {
        StartCoroutine(AttackCoroutine());
    }

    public override void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Pursue()
    {
        throw new System.NotImplementedException();
    }
}
