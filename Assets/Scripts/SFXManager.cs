using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("UI SFX")]
    public AudioClip buttonClick;
    public AudioClip popupAppear;

    [Header("Game SFX")]
    public AudioClip goalReached;
    public AudioClip wrongAction;
    public AudioClip restartLevel;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // 🎯 Méthode générique (interne)
    private void Play(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.PlayOneShot(clip);
    }

    // 👇 Méthodes publiques simples

    public void PlayButtonClick()
    {
        Play(buttonClick);
    }

    public void PlayPopup()
    {
        Play(popupAppear);
    }

    public void PlayGoalReached()
    {
        Play(goalReached);
    }

    public void PlayWrongAction()
    {
        Play(wrongAction);
    }

    public void PlayRestart()
    {
        Play(restartLevel);
    }
}
