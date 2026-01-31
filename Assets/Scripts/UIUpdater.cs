using System;
using System.Collections.Generic;
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

    [Header("Deco")]
    public Color normalColor = Color.white;
    public Color goalReachedColor = Color.blue;
    public GameObject cadenas;

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
            cadenas.GetComponent<ManualUIImageAnimator>().Play();

        // History
        historyText.text = "";
        foreach (int value in numberManager.history)
        {
            historyText.text += ToBinaryString(value) + "\n";
        }
    }

    public void UpdateButtonText(NumberButton button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

        string symbol = "";
        switch(button.bitMaskOperator)
        {
            case Operators.AND :
                symbol = "&";
                break;
            case Operators.NAND :
                symbol = "~&";
                break;
            case Operators.OR :
                symbol = "|";
                break;
            case Operators.NOR :
                symbol = "~|";
                break;
            case Operators.XOR :
                symbol = "^";
                break;
            case Operators.INVERT :
                symbol = "~";
                break;
            case Operators.SHIFTLEFT :
                symbol = "<<";
                break;
            case Operators.SHIFTRIGHT :
                symbol = ">>";
                break;
        }

        buttonText.text = symbol + " " + ToBinaryString(button.valueToAdd);
    }

    public string ToBinaryString(int number)
    {
        return Convert.ToString(number, 2).PadLeft(bitLength, '0');
    }
}
