using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject profileMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void ToggleProfileMenu()
    {
        if(profileMenu.activeSelf)
        {
            profileMenu.SetActive(false);
        }
        else
        {
            profileMenu.SetActive(true);
        }
    }
}
