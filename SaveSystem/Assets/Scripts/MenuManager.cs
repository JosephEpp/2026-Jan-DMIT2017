using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject profileMenu;
    [SerializeField] public GameObject startMenu;
    [SerializeField] public GameObject deleteMenu;
    [SerializeField] public GameObject newProfileMenu;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public jsonSaving saveSystem;
    [SerializeField] private SaveSystem ghostDataSave;

    [SerializeField] public List<SaveProfile> leaderboardProfiles;
    [SerializeField] public List<ProfileDisplay> leaderboardDisplayItems;
    [SerializeField] public SaveProfile newProfile;

    private int numberOfSaveFiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        numberOfSaveFiles = saveSystem.CountSaveFiles();

        SetLeaderboard();
    }

    public void SetLeaderboard()
    {
        //Load each of the profiles into the list
        for(int i = 0; i < numberOfSaveFiles; i++)
        {
            saveSystem.LoadData(i);

            leaderboardProfiles.Add(saveSystem.profileData);
        }

        //Fill the leaderboard in order
        leaderboardProfiles = leaderboardProfiles.OrderByDescending(s => s.highScore).ToList();

        for(int i = 0; i <= 4; i++)
        {
            leaderboardDisplayItems[i].SetDisplay(leaderboardProfiles[i]);
        }
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
            startMenu.SetActive(false);
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

    public void ToggleStartMenu()
    {
        if(startMenu.activeSelf)
        {
            startMenu.SetActive(false);
        }
        else
        {
            startMenu.SetActive(true);
            newProfileMenu.SetActive(false);
            profileMenu.SetActive(false);
        }
    }

    public void SetActiveProfile(int profileIndex)
    {
        gameManager.SetActiveProfile(leaderboardProfiles[profileIndex]);
    }

    public void SetActiveProfileType(int type)
    {
        gameManager.activeProfile.vehicleType = type;
    }

    public void SetActiveProfileColor(string color)
    {
        gameManager.activeProfile.color = color;
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

    public void DeleteProfile()
    {
        ghostDataSave.DeleteSave(gameManager.activeProfile);
        saveSystem.DeleteData(gameManager.activeProfile);
    }
}
