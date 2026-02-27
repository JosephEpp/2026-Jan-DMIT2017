using UnityEngine;
using System.IO;

public class JSonSaving : MonoBehaviour
{
    //public string filePath;
    public string saveName;

    [ContextMenu("JSON Save")]
    public void SaveData()
    {
        //string file = filePath + saveName + ".json";
        // string filePathFixed = Path.Combine(Application.persistentDataPath, saveName + ".json"); <-- use this line instead for your build
        string filePathFixed = Path.Combine("Assets/Resources", saveName + ".json");
        string json = JsonUtility.ToJson(GameStateManager.instance.gameState, true);

        File.WriteAllText(filePathFixed, json);
    }

    public void LoadData()
    {
        //Load game data from the active save
    }

    public void LoadNewGame()
    {
        //Overwrite the active save's data with the default data
    }

    public void SaveAndQuit()
    {
        SaveData();
        Application.Quit();
    }
}