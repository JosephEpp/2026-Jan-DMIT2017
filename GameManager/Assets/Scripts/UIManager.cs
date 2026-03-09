using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    private InputAction pauseAction, inventoryAction;
    public GameObject pauseMenu, inventoryMenu;
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI healthDisplay;

    private PlayerCombatController player;
    private int gold = 0;
    private int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerCombatController>();

        pauseAction = InputSystem.actions.FindAction("Pause");
        pauseAction.performed += Context => Pause();

        inventoryAction = InputSystem.actions.FindAction("Inventory");
        inventoryAction.performed += Context => Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(gold != GameStateManager.instance.gameState.treasure)
        {
            gold = GameStateManager.instance.gameState.treasure;
            goldDisplay.text = $"{gold}";
        }

        if(health != player.currentHP)
        {
            health = player.currentHP;
            healthDisplay.text = $"{health}";
        }
    }

    public void Pause()
    {
        if(pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Inventory()
    {
        if(inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            inventoryMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
