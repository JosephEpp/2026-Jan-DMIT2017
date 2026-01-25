using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text vehicle;
    [SerializeField] private TMP_Text color;
    [SerializeField] private TMP_Text highScore;

    public void SetDisplay(SaveProfile saveProfile)
    {
        playerName.text = saveProfile.profileName;
        vehicle.text = "Vehicle:" + saveProfile.vehicleType.ToString();
        color.text = "Color:" + saveProfile.color;
        highScore.text = "High Score:" + saveProfile.highScore.ToString();
    }
}
