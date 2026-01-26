using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public List<SaveProfile> profiles = new List<SaveProfile>();
    public string filePathStarter;

    public void CreateSave(SaveProfile profile)
    {
        string filePath = filePathStarter + "GhostData" + profile.ghostIndex + ".csv";
        bool fileExists = File.Exists(filePath);

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            if(!fileExists)
            {
                sw.WriteLine("Profile Name, Score, Vehicle Type, Color, GhostIndex");
            }

            sw.WriteLine($"{profile.profileName}, {profile.highScore}, {profile.vehicleType}, {profile.color}, {profile.ghostIndex}");

            profiles.Add(profile);
        }
    }

    public void DeleteSave()
    {
        
    }

    public void LoadSave(SaveProfile profile)
    {
        int highScore = 0;
        string filePath = filePathStarter + "GhostData" + profile.ghostIndex + ".csv";
        string[] lines = File.ReadAllLines(filePath);

        for(int i = 0; i < lines.Length; i++)
        {
            string[] columns = Regex.Split(lines[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            if(columns[0] == profiles[profile.ghostIndex].profileName)
            {
                highScore = int.Parse(columns[1]);
                break;
            }
        }

        Debug.Log(highScore);
    }

    public void SaveGhostData(SaveProfile profile, GhostData ghostData)
    {
        string filePath = filePathStarter + "GhostData" + profile.ghostIndex + ".csv";
        bool fileExists = File.Exists(filePath);

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            if(!fileExists)
            {
                sw.WriteLine("xP, yP, zP, xR, yR, zR");
            }

            for(int i = 0; i < ghostData.ghostDataFrames.Count; i++)
            {
                sw.WriteLine($"{ghostData.ghostDataFrames[i].position.x},{ghostData.ghostDataFrames[i].position.y},{ghostData.ghostDataFrames[i].position.z},{ghostData.ghostDataFrames[i].rotation.x},{ghostData.ghostDataFrames[i].rotation.y},{ghostData.ghostDataFrames[i].rotation.z}");
            }
        }
    }
}

[Serializable]
public class SaveProfile
{
    public string profileName;
    public int highScore;
    public int vehicleType;
    public string color;
    public int ghostIndex;

    public SaveProfile(string profileName_, int highScore_, int vehicleType_, string color_, int ghostIndex_)
    {
        profileName = profileName_;
        highScore = highScore_;
        vehicleType = vehicleType_;
        color = color_;
        ghostIndex = ghostIndex_;
    }
}