using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonSaving : MonoBehaviour
{
    public string filePathStarter;
    public SaveProfile profileData;

    [ContextMenu("JSON Save")]
    public void SaveData(SaveProfile saveProfile_)
    {
        string json = JsonUtility.ToJson(saveProfile_, true);

        string filePath = filePathStarter + "Profile" + saveProfile_.ghostIndex + ".json";

        //Version of saving that works for builds
        //string file = Path.Combine(Application.persistentDataPath, filePath);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]
    public void LoadData(int profileNumber_)
    {
        string loadFilePath = filePathStarter + "Profile" + profileNumber_ + ".json";

        if(File.Exists(loadFilePath))
        {
            string json = File.ReadAllText(loadFilePath);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }
        else
        {
            Debug.Log("File not found");
        }
    }

    [ContextMenu("JSON Delete")]
    public void DeleteData(SaveProfile profile_)
    {
        // List<SaveProfile> saveProfiles = new List<SaveProfile>();

        // saveProfiles.RemoveAt(0); //Set to index

        string filePath = filePathStarter + "Profile" + profile_.ghostIndex + ".json";
        bool fileExists = File.Exists(filePath);

        if(fileExists)
        {
            File.Delete(filePath);
        }
    }

    [ContextMenu("JSON New Save")]
    public void NewSaveData(string name, int highscore, int vehicleType, string color, int ghostIndex)
    {
        SaveProfile saveProfile = new SaveProfile(name, highscore, vehicleType, color, ghostIndex);

        string json = JsonUtility.ToJson(saveProfile, true);

        string filePath = filePathStarter + "Profile" + saveProfile.ghostIndex + ".json";

        File.WriteAllText(filePath, json);
    }

    public int CountSaveFiles()
    {
        int numberOfSaveFiles = 0;

        for(int i = 0; i < 20; i++)
        {
            string fileToCheck = filePathStarter + "Profile" + i + ".json";

            if(File.Exists(fileToCheck))
            {
                numberOfSaveFiles++;
            }
        }

        return numberOfSaveFiles;
    }
}
