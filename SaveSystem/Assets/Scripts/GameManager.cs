using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public SaveProfile activeProfile;

    private void Awake()
    {
        CreateSingleton();
    }

    private void CreateSingleton()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
