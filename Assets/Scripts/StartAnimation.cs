using System.Collections;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject screen;
    public float animationDuration = 4.6f;
    public ManualSpriteAnimator animator;
    public void PlayAnimation()
    {
        screen.SetActive(false);
        animator.Play();
        StartCoroutine(StartAnimationDelay());
    }

    private IEnumerator StartAnimationDelay()
    {
        yield return new WaitForSeconds(animationDuration);
        this.gameObject.SetActive(false);
        screen.SetActive(true);
        animator.ResetAnimation();
    }
}
