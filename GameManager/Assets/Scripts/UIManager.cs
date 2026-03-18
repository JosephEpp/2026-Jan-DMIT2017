using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public InputAction pauseAction, inventoryAction, closeMenuAction;
    public GameObject pauseMenu, inventoryMenu, containerMenu;
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI healthDisplay;

    public InventoryUIManager inventoryUIManager;
    public InventoryManager inventoryManager;

    private PlayerCombatController player;
    private int gold = 0;
    private int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerCombatController>();

        pauseAction.performed += Context => Pause();

        inventoryAction.performed += Context => Inventory();

        closeMenuAction.performed += Context => CloseMenu();

        inventoryUIManager.InitUI();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
        inventoryAction.Enable();
        closeMenuAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.Disable();
        inventoryAction.Disable();
        closeMenuAction.Disable();
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
            inventoryUIManager.UpdateUI();
            inventoryMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseMenu()
    {
        if(pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if(inventoryMenu.activeSelf)
        {
            inventoryMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if(containerMenu.activeSelf)
        {
            containerMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
