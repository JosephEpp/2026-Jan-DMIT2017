using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private jsonSaving saveSystem;

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
            gameManager.score++;
            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("Player"))
        {
            //End the race if the score is greater than 0
            if(gameManager.score > 0)
            {
                //Overwrite save data
                saveSystem.SaveData(gameManager.activeProfile);

                //Return to title screen
                SceneManager.LoadScene(0);
            }
        }
    }
}
