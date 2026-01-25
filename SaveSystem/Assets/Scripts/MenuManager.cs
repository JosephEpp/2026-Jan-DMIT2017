using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject profileMenu;
    [SerializeField] public GameObject gameManager;
    [SerializeField] public jsonSaving saveSystem;

    [SerializeField] public GameObject profile1;
    [SerializeField] public GameObject profile2;
    [SerializeField] public GameObject profile3;
    [SerializeField] public GameObject profile4;
    [SerializeField] public GameObject profile5;
    [SerializeField] public GameObject newProfile;
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
