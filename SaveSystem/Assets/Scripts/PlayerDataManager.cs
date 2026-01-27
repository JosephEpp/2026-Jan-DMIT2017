using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private jsonSaving saveSystem;
    [SerializeField] private SaveSystem ghostDataSave;

    [SerializeField] private CarFollow carFollow;
    [SerializeField] private GameObject carType1;
    [SerializeField] private GameObject carType2;
    private GameObject activeCar;


    [SerializeField] private GameObject overwriteMenu;

    private GameManager gameManager;
    private GhostDataRecorder ghostDataRecorder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        //Set the car type and remove the inactive car
        if(gameManager.activeProfile.vehicleType == 1)
        {
            activeCar = carType1;
            carType1.SetActive(true);
            carType2.SetActive(false);
        }
        else
        {
            activeCar = carType2;
            carType1.SetActive(false);
            carType2.SetActive(true);
        }
        carFollow.SetActiveCar(activeCar);

        //Get Ghostdata Recorder
        ghostDataRecorder = activeCar.GetComponent<GhostDataRecorder>();

        //Set the active car's color
        Renderer renderer = activeCar.GetComponent<Renderer>();

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
                ghostDataRecorder.StopRecording();
                Time.timeScale = 0;
                overwriteMenu.SetActive(true);
            }
        }
    }

    public void OnOverwriteSave()
    {
        //Record data to profile
        if(gameManager.activeProfile.highScore < gameManager.score)
        {
            gameManager.activeProfile.highScore = gameManager.score;
        }

        //Save data
        saveSystem.SaveData(gameManager.activeProfile);
        ghostDataSave.SaveGhostData(gameManager.activeProfile, ghostDataRecorder.ghostData);

        //Return to title screen
        ReturnToTitle();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
