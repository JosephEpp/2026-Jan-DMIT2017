using UnityEngine;
using System.IO;

public class JSonSaving : MonoBehaviour
{
    //public string filePath;
    public string saveName;
    private GameState gameState;
    private string defualtSaveFilePath = Path.Combine("Assets/Resources", "DefaultSave" + ".json");
    //private string defualtSaveFilePath; //<-- Use this line for the build
    private string activeSaveFilePath = Path.Combine("Assets/Resources", "ActiveSave" + ".json");
    //private string activeSaveFilePath; //<-- Use this line for the build

    void Awake()
    {
        //defualtSaveFilePath = Path.Combine(Application.persistentDataPath, "DefaultSave" + ".json"); //<-- Use this line for the build
        //activeSaveFilePath = Path.Combine(Application.persistentDataPath, "ActiveSave" + ".json");   //<-- Use this line for the build
        if(GameStateManager.instance != null)
        {
            string json = File.ReadAllText(activeSaveFilePath);

            GameStateManager.instance.gameState = JsonUtility.FromJson<GameState>(json);
        }
    }

    [ContextMenu("JSON Save")]
    public void SaveData()
    {
        //string file = filePath + saveName + ".json";
        //string filePathFixed = Path.Combine(Application.persistentDataPath, saveName + ".json"); //<-- Use this line for the build
        string filePathFixed = Path.Combine("Assets/Resources", saveName + ".json");           //<-- Use this line in the editor
        
        if(File.Exists(filePathFixed))
        {
            string json = JsonUtility.ToJson(GameStateManager.instance.gameState, true);

            File.WriteAllText(filePathFixed, json);
        }
    }

    public void LoadData()
    {
        //Load game data from the active save
        //string filePathFixed = Path.Combine(Application.persistentDataPath, saveName + ".json"); //<-- Use this line for the build
        string filePathFixed = Path.Combine("Assets/Resources", saveName + ".json");           //<-- Use this line in the editor

        if(File.Exists(filePathFixed))
        {
            string json = File.ReadAllText(filePathFixed);

            gameState = JsonUtility.FromJson<GameState>(json);

            LoadDataToActiveSave();
        }
        else
        {
            Debug.Log("File not found");
        }
    }

    public void LoadNewGame()
    {
        //Overwrite the active save's data with the default data
        if(File.Exists(defualtSaveFilePath))
        {
            string json = File.ReadAllText(defualtSaveFilePath);

            gameState = JsonUtility.FromJson<GameState>(json);

            LoadDataToActiveSave();
        }
        else
        {
            Debug.Log("File not found");
        }
    }

    public void LoadDataToActiveSave()
    {
        string json = JsonUtility.ToJson(gameState, true);

        File.WriteAllText(activeSaveFilePath, json);
    }

    public void SaveAndQuit()
    {
        SaveData();
        Application.Quit();
    }
}