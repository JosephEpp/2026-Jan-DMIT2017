using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject profileMenu;
    [SerializeField] public GameObject deleteMenu;
    [SerializeField] public GameObject newProfileMenu;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public jsonSaving saveSystem;

    [SerializeField] public List<SaveProfile> leaderboardProfiles;
    [SerializeField] public List<ProfileDisplay> leaderboardDisplayItems;
    [SerializeField] public SaveProfile newProfile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        
        //Load each of the profiles into the list
        for(int i = 0; i < leaderboardProfiles.Count; i++)
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
        gameManager.score = 0;
        Time.timeScale = 1;
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
            newProfileMenu.SetActive(false);
        }
    }

    public void ToggleDeleteMenu()
    {
        if(deleteMenu.activeSelf)
        {
            deleteMenu.SetActive(false);
        }
        else
        {
            deleteMenu.SetActive(true);
        }
    }

    public void ToggleNewProfileMenu()
    {
        if(newProfileMenu.activeSelf)
        {
            newProfileMenu.SetActive(false);
        }
        else
        {
            newProfileMenu.SetActive(true);
        }
    }

    public void SetActiveProfile(int profileIndex)
    {
        gameManager.SetActiveProfile(leaderboardProfiles[profileIndex]);
    }

    public void SetNewProfileName(TMP_Text name)
    {
        newProfile.profileName = name.text;
    }

    public void SetNewProfileColor(string color)
    {
        newProfile.color = color;
    }
    
    public void CreateNewProfile()
    {
        int newGhostIndex = leaderboardProfiles.Count;

        newProfile.ghostIndex = newGhostIndex;

        newProfile.vehicleType = 1;

        saveSystem.NewSaveData(newProfile.profileName, newProfile.highScore, newProfile.vehicleType, newProfile.color, newProfile.ghostIndex);

        gameManager.SetActiveProfile(newProfile);

        leaderboardProfiles.Add(newProfile);
    }
}
