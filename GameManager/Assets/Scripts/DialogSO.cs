using UnityEngine;

[CreateAssetMenu(fileName = "DialogSO", menuName = "Dialog System/DialogSO")]
public class DialogSO : ScriptableObject
{
    //public int id;
    public string dialogLine;
    public string speakerName;
    public Sprite portrait;
}