using System;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [Header("References")]
    public NumberManager numberManager;
    public int bitLength { get; set; }


    [Header("Text Elements")]
    public TMP_Text currentNumberText;
    public TMP_Text goalText;
    public TMP_Text historyText;
    public TMP_Text baseText;

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
        currentNumberText.text = ToBinaryString(numberManager.currentNumber);

        // Goal
        goalText.text = ToBinaryString(numberManager.goalNumber);

        // Base number
        baseText.text = ToBinaryString(numberManager.baseNumber);

        // Color when goal reached
        currentNumberText.color = numberManager.IsGoalReached()
            ? goalReachedColor
            : normalColor;

        // History
        historyText.text = "";
        foreach (int value in numberManager.history)
        {
            historyText.text += ToBinaryString(value) + "\n";
        }
    }
    public string ToBinaryString(int number)
    {
        return Convert.ToString(number, 2).PadLeft(bitLength, '0');
    }
}
