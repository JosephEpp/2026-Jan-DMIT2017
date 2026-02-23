using UnityEngine;

public class Inn : MonoBehaviour
{
    private PlayerCombatController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Rest()
    {
        GameStateManager.instance.ResetEnemies();
        GameStateManager.instance.SaveGameState();

        player = FindFirstObjectByType<PlayerCombatController>();
        player.FullHeal();
    }
}
