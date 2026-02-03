using System.Collections;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private SpriteRenderer sr;
    bool isPlaying = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    public void InitializeAnimation(AnimationData animationData)
    {

        StopAllCoroutines();
        StartCoroutine(PlayAnimation(animationData));
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

    public void StopPlaying()
    {
        isPlaying = false;
    }
}
