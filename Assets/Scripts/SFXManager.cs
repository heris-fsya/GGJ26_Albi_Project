using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource sfxSource;
    public AudioSource musicSourceMenu;
    public AudioSource musicSource;
    public AudioListener audioListener;

    [Header("UI SFX")]
    public AudioClip buttonClick;
    public AudioClip popupAppear;
    public Slider volumeSlider;

    [Header("Game SFX")]
    public AudioClip goalReached;
    public AudioClip wrongAction;
    public AudioClip restartLevel;


    [Header("Music")]
    public AudioClip gameplayMusic;
    public AudioClip victoryMusic;
      private void Awake()
    {
        // Sécurité
        if (audioListener == null)
            audioListener = GetComponent<AudioListener>();

        if (sfxSource == null || musicSource == null)
            Debug.LogError("AudioManager : AudioSource manquant !");
    }

    // 🎯 Méthode générique (interne)
    private void Play(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        sfxSource.Stop();
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

    public void PlayMusic(AudioClip music)
    {
        if (music == null) return;

        if (musicSource.clip == music) return;

        musicSource.Stop();
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(victoryMusic);
    }

    public void ChangeVolume()
    {
        musicSourceMenu.volume = volumeSlider.value;
        musicSource.volume = volumeSlider.value;
        sfxSource.volume = volumeSlider.value;
    }
}
