using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject profileMenu;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public jsonSaving saveSystem;

    [SerializeField] public List<SaveProfile> leaderboardProfiles;
    [SerializeField] public List<ProfileDisplay> leaderboardDisplayItems;
    [SerializeField] public SaveProfile newProfile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Load each of the profiles into the list
        for(int i = 0; i <= 4; i++)
        {
            saveSystem.LoadData(i);

            leaderboardProfiles[i] = saveSystem.profileData;
        }

        //Fill the leaderboard in order
        leaderboardProfiles = leaderboardProfiles.OrderByDescending(s => s.highScore).ToList();

        for(int i = 0; i <= 4; i++)
        {
            leaderboardDisplayItems[i].SetDisplay(leaderboardProfiles[i]);
        }
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

    public void SetActiveProfile(int profileIndex)
    {
        gameManager.SetActiveProfile(leaderboardProfiles[profileIndex]);
    }
}
