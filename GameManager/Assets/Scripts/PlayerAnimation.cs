using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    public List<AnimationStateData> animations = new List<AnimationStateData>();
    private SpriteRenderer sr;
    bool isPlaying = false;

    private Dictionary<PlayerAnimationState, AnimationData> animationDictionary = new Dictionary<PlayerAnimationState, AnimationData>();

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        TopDownPlayerMovement playerMovement = GetComponent<TopDownPlayerMovement>();
        playerMovement.OnMove += SetAnimationState;

        foreach(AnimationStateData animationStateData in animations)
        {
            animationDictionary.Add(animationStateData.state, animationStateData.animation);
        }
    }

    public void InitializeAnimation(AnimationData animationData)
    {
        StartCoroutine(PlayAnimation(animationData));
    }

    public void SetAnimationState(Vector2 moveDirection)
    {
        Debug.Log(moveDirection);

        PlayerAnimationState currentState;

        //Using a switch case check the players state
        // y > 0 = WALK_UP

        //How to handle idle animations?
    }

    private IEnumerator PlayAnimation(AnimationData animation)
    {
        isPlaying = true;
        sr.sprite = animation.frames[0];
        int frameCount = animation.frames.Length;
        int frameIndex = 0;

        while (isPlaying)
        {
            yield return new WaitForSeconds(animation.frameDelay);
            frameIndex++;
            if (frameIndex >= animation.frames.Length) frameIndex = 0;
            sr.sprite = animation.frames[frameIndex];

            yield return null;
        }
        yield return null;
    }
}

[CreateAssetMenu(fileName = "Animation", menuName = "Animation")]
public class AnimationData : ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;
}

public enum PlayerAnimationState
{
    WALK_UP,
    WALK_DOWN,
    WALK_RIGHT,
    WALK_LEFT,
    IDLE_UP,
    IDLE_DOWN,
    IDLE_RIGHT,
    IDLE_LEFT
}

[Serializable]
public class AnimationStateData
{
    public PlayerAnimationState state;
    public AnimationData animation;
}