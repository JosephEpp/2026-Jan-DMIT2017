using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
public abstract class Enemy : MonoBehaviour
{
    public int enemyID;
    [Header("Combat Params")]
    public int HP;
    public int ATK;
    public int DEF;
    public float attackDelay;

    [Header("Behavior Ranges")]
    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    protected Vector2 playerPosition;
    private Coroutine attackCoroutine;

    public Vector2 patrolRange;
    private Vector2 startingPosition;
    private Vector2 nextPosition;
    private AIMovement aiMovement;
    protected PlayerCombatController player;

    private bool patroling;

    public abstract void Attack();

    [ContextMenu("Try Die")]
    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        startingPosition = transform.position;
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;
        aiMovement = GetComponent<AIMovement>();
        player = FindFirstObjectByType<PlayerCombatController>();
        aiMovement.OnArrive += Patrol;
    }

    private void Update()
    {
        if (attackRange.CircleOverlapCheck())
        {
            aiMovement.StopMovement();
            StartAttackCoroutine();
            return;
        }

        if (sightline.CircleOverlapCheck())
        {
            aiMovement.StopMovement();
            Pursue();

            return;
        }
        if (!patroling)
        {
            Patrol();
            patroling = true;
        }
    }

    public void SetPlayerPosition(Vector2 pos_)
    {
        playerPosition = pos_;
    }
    public void Patrol()
    {
        nextPosition = new Vector2(Random.Range(startingPosition.x - patrolRange.x, startingPosition.x + patrolRange.x),
            Random.Range(startingPosition.y - patrolRange.y, startingPosition.y + patrolRange.y));
        aiMovement.InitializeMovement(nextPosition);
    }

    public void TakeDamage(int dmg_)
    {
        int totalDamage = dmg_ - DEF;
        if(totalDamage <= 0)
        {
            totalDamage = 1;
        }

        HP -= totalDamage;

        if(HP <= 0)
        {
            Die();
        }
    }
    public void Pursue()
    {
        aiMovement.InitializeMovement(playerPosition);
    }
    public void StartAttackCoroutine()
    {
        if (attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());
    }
    public IEnumerator AttackCoroutine()
    {
        while (attackRange.CircleOverlapCheck())
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        attackCoroutine = null;
    }


}