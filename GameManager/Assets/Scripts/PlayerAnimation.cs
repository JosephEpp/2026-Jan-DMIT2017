using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerMovement))]
[RequireComponent(typeof(SpriteAnimator))]
public class PlayerAnimation : MonoBehaviour
{
    public List<AnimationStateData> animations = new List<AnimationStateData>();

    private SpriteAnimator spriteAnimator;
    private PlayerAnimationState currentState = PlayerAnimationState.IDLE_DOWN;
    private Dictionary<PlayerAnimationState, AnimationData> animationDictionary = new Dictionary<PlayerAnimationState, AnimationData>();

    public void Start()
    {
        TopDownPlayerMovement playerMovement = GetComponent<TopDownPlayerMovement>();
        playerMovement.OnMove += SetAnimationState;

        foreach(AnimationStateData animationStateData in animations)
        {
            animationDictionary.Add(animationStateData.state, animationStateData.animation);
        }
    }

    public void SetAnimationState(Vector2 moveDirection)
    {
        //Debug.Log(moveDirection);

        if(moveDirection.y > 0)
        {
            currentState = PlayerAnimationState.WALK_UP;
        }
        else if(moveDirection.y < 0)
        {
            currentState = PlayerAnimationState.WALK_DOWN;
        }
        else if(moveDirection.x > 0)
        {
            currentState = PlayerAnimationState.WALK_RIGHT;
        }
        else if(moveDirection.x < 0)
        {
            currentState = PlayerAnimationState.WALK_LEFT;
        }

        if(moveDirection == Vector2.zero)
        {
            currentState = GetIdleState(currentState);
        }

        spriteAnimator.InitializeAnimation(animationDictionary[currentState]);
    }

    private PlayerAnimationState GetIdleState(PlayerAnimationState currentState)
    {
        PlayerAnimationState state = PlayerAnimationState.IDLE_DOWN;

        switch (currentState)
        {
            case PlayerAnimationState.WALK_UP: 
                state = PlayerAnimationState.IDLE_UP;
                break;
            case PlayerAnimationState.WALK_DOWN: 
                state = PlayerAnimationState.IDLE_DOWN;
                break;
            case PlayerAnimationState.WALK_LEFT:
                state = PlayerAnimationState.IDLE_LEFT;
                break;
            case PlayerAnimationState.WALK_RIGHT:
                state = PlayerAnimationState.IDLE_RIGHT;
                break;
            default:
                break;
        }

        return state;
    }
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