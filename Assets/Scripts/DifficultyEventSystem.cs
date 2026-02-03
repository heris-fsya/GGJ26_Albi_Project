using UnityEngine;
using UnityEngine.Events;

public class DifficultyEventSystem : MonoBehaviour
{
    [Header("Settings")]
    public float minDelay = 40f;
    public float maxDelay = 90f;

    [Header("References")]
     public AudioSource audio;
    public AudioClip Easyaudio;
    public AudioClip Hardaudio;

    public DifficultyPopup popup;
    public UnityEvent onDifficultEvent;

    private bool isActive = false;
    private float timer;
    private float nextTriggerTime;

    public void Configure(Difficulty difficulty)
    {
        isActive = (difficulty == Difficulty.HARD);

        if (isActive)
            ScheduleNextEvent();
    }

    public void setAudioClip(Difficulty difficulty)
    {
        AudioClip currentAudio = audio.clip;

        if (difficulty == Difficulty.EASY || difficulty == Difficulty.MEDIUM)
        {
            audio.clip = Easyaudio;
        }
        else if (difficulty == Difficulty.HARD)
        {
            audio.clip = Hardaudio;
        }

        if(audio.clip != currentAudio)
        {
            audio.Play();
        }
    }

    void Update()
    {
        if (!isActive)
            return;

        timer += Time.deltaTime;

        if (timer >= nextTriggerTime)
        {
            TriggerEvent();
            ScheduleNextEvent();
        }
    }

    void ScheduleNextEvent()
    {
        timer = 0f;
        nextTriggerTime = Random.Range(minDelay, maxDelay);
    }

    void TriggerEvent()
    {
        Debug.Log("Difficult Event Triggered!");
        onDifficultEvent?.Invoke();
        popup.Show();
    }

        void TriggerPopupEvent()
    {
        Debug.Log("Popup Event Triggered");
        
    }
}
