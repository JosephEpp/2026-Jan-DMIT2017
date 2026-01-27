using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Scriptable Objects/Animation")]
public class AnimationData : ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;
}
