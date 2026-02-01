using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventPopupController : MonoBehaviour
{
    [Header("UI")]
    public GameObject popupRoot;
    public TMP_Text countdownText;
    public Button closeButton;


    [Header("Settings")]
    public float countdownDuration = 5f;

    public SFXManager sfxManager;
    private Coroutine countdownCoroutine;
    private bool isActive = false;

    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        popupRoot.SetActive(false);

        closeButton.onClick.AddListener(DeactivatePopup);
    }

    // 🔔 Appelé par ton système d'event (mode difficile)
    public void ShowPopup()
    {
        if (isActive) return;
        sfxManager.PlayPopup();
        isActive = true;
        popupRoot.SetActive(true);

        countdownCoroutine = StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        float remaining = countdownDuration;

        while (remaining > 0f)
        {
            countdownText.text = Mathf.CeilToInt(remaining).ToString();
            remaining -= Time.deltaTime;
            yield return null;
        }
        sfxManager.PlayRestart();
        yield return new WaitForEndOfFrame(); // Wait for a frame to ensure audio plays properly
        sfxManager.PlayWrongAction();
        // ⛔ Temps écoulé → restart
        ForceRestart();
    }

    // ✅ Bouton cliqué
    public void DeactivatePopup()
    {
        if (!isActive) return;

        isActive = false;

        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        popupRoot.SetActive(false);
    }

    private void ForceRestart()
    {
        isActive = false;
        popupRoot.SetActive(false);

        Debug.Log("Event non désactivé → Restart Level");

        levelLoader.RestartLevel();
    }
}
