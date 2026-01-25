using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonSaving : MonoBehaviour
{
    public string filePath;
    public SaveProfile profileData;

    [ContextMenu("JSON Save")]
    public void SaveData(SaveProfile saveProfile_)
    {
        string json = JsonUtility.ToJson(saveProfile_, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]
    public void LoadData(int profileNumber_)
    {
        string loadFilePath = filePath + "Profile" + profileNumber_ + ".json";

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

        string filePath = "Assets/Resources/" + profile_.profileName + ".json";
        File.Delete(filePath);
    }

    public void NewSaveData(string name, int highscore, int vehicleType, string color, int ghostIndex)
    {
        SaveProfile saveProfile = new SaveProfile(name, highscore, vehicleType, color, ghostIndex);

        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }
}
