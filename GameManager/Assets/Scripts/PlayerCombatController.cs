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
        Instantiate(attackPrefab, attackSpawn.position, Quaternion.identity);
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
}
