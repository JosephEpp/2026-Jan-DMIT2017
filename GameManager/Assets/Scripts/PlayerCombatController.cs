using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    public InputAction attackInput;
    public Transform attackSpawn;
    public GameObject attackPrefab;

    [Header("Player Stats")]
    public int currentHP;
    public int maxHP;
    public int ATK;
    public int DEF;

    private void Start()
    {
        attackInput.Enable();
        attackInput.performed += Attack;
    }
    
    public void Attack(InputAction.CallbackContext context)
    {
        GameObject obj = Instantiate(attackPrefab, attackSpawn.position, Quaternion.identity);
        SimpleProjectile projectile = obj.GetComponent<SimpleProjectile>();

        Vector2 projectileVelocity = attackInput.ReadValue<Vector2>();
        projectileVelocity.Normalize();
        projectile.InstantiateProjectile(projectileVelocity, ATK);
    }

    public void TakeDamage(int dmg_)
    {
        int totalDamage = dmg_ - DEF;
        if(totalDamage <= 0)
        {
            totalDamage = 1;
        }

        currentHP -= totalDamage;
    }

    public void FullHeal()
    {
        currentHP = maxHP;
    }
}
