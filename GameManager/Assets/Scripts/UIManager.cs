using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI healthDisplay;

    private PlayerCombatController player;
    private int gold = 0;
    private int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerCombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gold != GameStateManager.instance.treasure)
        {
            gold = GameStateManager.instance.treasure;
            goldDisplay.text = $"{gold}";
        }

        if(health != player.currentHP)
        {
            health = player.currentHP;
            healthDisplay.text = $"{health}";
        }
    }
}
