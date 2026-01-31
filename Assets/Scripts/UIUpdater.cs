using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [Header("References")]
    public NumberManager numberManager;
    public LevelLoader levelLoader;
    public int bitLength { get; set; }
    private bool isLevelEnding = false;


    [Header("Text Elements")]
    public TMP_Text currentNumberText;
    public TMP_Text goalText;
    public TMP_Text historyText;
    public TMP_Text baseText;

    [Header("Deco")]
    public Color normalColor = Color.white;
    public Color goalReachedColor = Color.blue;
    public Color goalLockedColor = Color.red;
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
        cadenas.GetComponent<Image>().color = goalLockedColor;
        UpdateUI();
    }

private void Update()
{
    if (numberManager.IsGoalReached() && !isLevelEnding)
    {
        StartCoroutine(LevelCompleteRoutine());
    }
}

private IEnumerator LevelCompleteRoutine()
{
    isLevelEnding = true;

    UnityEngine.Debug.Log("Niveau terminé !");

    ManualUIImageAnimator cadenasAnimator = cadenas.GetComponent<ManualUIImageAnimator>();
    cadenasAnimator.Play();
    cadenas.GetComponent<Image>().color = goalReachedColor;

    yield return new WaitForSeconds(2f);

    cadenasAnimator.Stop();
    cadenasAnimator.ResetAnimation();
    cadenas.GetComponent<Image>().color = goalLockedColor;

    levelLoader.NextLevel();

    isLevelEnding = false;
}


    void UpdateUI()
    {
        // Current number
        currentNumberText.text = ToBinaryString(numberManager.currentNumber);

        // Goal
        if(levelLoader.levels[levelLoader.currentLevelIndex].showGoalDecimal)
        {
            goalText.text = numberManager.goalNumber.ToString();
        }
        else
        {
            goalText.text = ToBinaryString(numberManager.goalNumber);
        }

        // Base number
        baseText.text = ToBinaryString(numberManager.baseNumber);

        // Color when goal reached
        currentNumberText.color = numberManager.IsGoalReached()
            ? goalReachedColor 
            : normalColor; 

        // History
        historyText.text = "";
        foreach (uint value in numberManager.history)
        {
            historyText.text = ToBinaryString(value)  + "\n" + historyText.text;
        }
    }

    public void UpdateButtonText(NumberButton button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

        string text = "";
        switch(button.bitMaskOperator)
        {
            case Operators.AND :
                text = "& " + ToBinaryString(button.value);
                break;
            case Operators.NAND :
                text = "~& " + ToBinaryString(button.value);
                break;
            case Operators.OR :
                text = "| " + ToBinaryString(button.value);
                break;
            case Operators.NOR :
                text = "~| " + ToBinaryString(button.value);
                break;
            case Operators.XOR :
                text = "^ " + ToBinaryString(button.value);
                break;
            case Operators.INVERT :
                text = "~";
                break;
            case Operators.SHIFTLEFT :
                text = "<< " + button.value;
                break;
            case Operators.SHIFTRIGHT :
                text = ">> " + button.value;
                break;
        }

        buttonText.text = text;
    }

    public string ToBinaryString(uint number)
    {
        return Convert.ToString(number, 2).PadLeft(bitLength, '0');
    }
}
