using System.Collections;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject screen;
    public float animationDuration = 4.3f;
    private ManualSpriteAnimator animator;

    void OnEnable()
    {
        if(!animator) animator = GetComponentInChildren<ManualSpriteAnimator>();

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
