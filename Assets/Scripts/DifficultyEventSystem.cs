using UnityEngine;
using UnityEngine.Events;

public class DifficultyEventSystem : MonoBehaviour
{
    [Header("Settings")]
    public float minDelay = 40f;
    public float maxDelay = 90f;

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
    }
}
