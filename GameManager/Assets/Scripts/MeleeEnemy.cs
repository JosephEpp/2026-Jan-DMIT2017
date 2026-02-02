using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
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
