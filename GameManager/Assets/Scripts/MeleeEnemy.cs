using UnityEngine;

public class MeleeEnemy : Enemy
{

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        HP -= 5;
    }

   

    public override void Pursue()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
