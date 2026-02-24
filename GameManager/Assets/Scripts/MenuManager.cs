using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
