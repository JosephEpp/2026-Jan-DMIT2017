using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private jsonSaving saveSystem;

    [SerializeField] private GameObject overwriteMenu;

    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        Renderer renderer = GetComponent<Renderer>();

        if(gameManager.activeProfile.color == "Blue")
        {
            renderer.material = blueMaterial;
        }
        else if(gameManager.activeProfile.color == "Red")
        {
            renderer.material = redMaterial;
        }
        else if(gameManager.activeProfile.color == "Green")
        {
            renderer.material = greenMaterial;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            gameManager.score++;
        }

        if(other.CompareTag("FinishLine"))
        {
            //End the race if the score is greater than 0
            if(gameManager.score > 0)
            {
                //Stop the game
                Time.timeScale = 0;

                overwriteMenu.SetActive(true);

                //Overwrite save data
                //saveSystem.SaveData(gameManager.activeProfile);

                //Return to title screen
                //SceneManager.LoadScene(0);
            }
        }
    }

    public void OnOverwriteSave()
    {
        //Save data

        //Return to title screen
        ReturnToTitle();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
