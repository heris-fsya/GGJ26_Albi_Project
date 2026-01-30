using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [Header("References")]
    public NumberManager numberManager;

    [Header("Text Elements")]
    public TMP_Text currentNumberText;
    public TMP_Text goalText;
    public TMP_Text historyText;

    [Header("Colors")]
    public Color normalColor = Color.white;
    public Color goalReachedColor = Color.blue;

    private void OnEnable()
    {
        numberManager.onNumberChanged.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        numberManager.onNumberChanged.RemoveListener(UpdateUI);
    }

    private void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        // Current number
        currentNumberText.text = numberManager.currentNumber.ToString();

        // Goal
        goalText.text = numberManager.goalNumber.ToString();

        // Color when goal reached
        currentNumberText.color = numberManager.IsGoalReached()
            ? goalReachedColor
            : normalColor;

        // History
        historyText.text = "";
        foreach (int value in numberManager.history)
        {
            historyText.text += value + "\n";
        }
    }
}
