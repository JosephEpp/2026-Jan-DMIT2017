using UnityEngine;
using UnityEngine.Events;

public class Inn : MonoBehaviour
{
    private PlayerCombatController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Rest()
    {
        GameStateManager.instance.ResetEnemies();

        player = FindFirstObjectByType<PlayerCombatController>();
        player.FullHeal();

        GameStateManager.instance.SaveGameState();

        ScreenFader screenFader = FindFirstObjectByType<ScreenFader>();
        screenFader.BeginScreenFade(1.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rest();
        }
    }
}
