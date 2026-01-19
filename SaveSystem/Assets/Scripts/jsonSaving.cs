using System.IO;
using UnityEngine;

public class jsonSaving : MonoBehaviour
{
    public string filePath;
    public SaveProfile profileData;

    [ContextMenu("JSON Save")]
    public void SaveData()
    {
        SaveProfile saveProfile = new SaveProfile("Joseph", 1010, 1, "Red", 0);

        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(filePath, json);
    }

    [ContextMenu("JSON Load")]
    public void LoadData()
    {
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }
        else
        {
            Debug.Log("File not found");
        }
    }
}
