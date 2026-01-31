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
    public Webcam webcam;
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
    public GameObject StopPanel;

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

        // Setup
        ManualUIImageAnimator cadenasAnimator = cadenas.GetComponent<ManualUIImageAnimator>();
        ManualSpriteAnimator portraitContentAnimator = webcam.portraitContentAnimator;
        webcam.portraitSuiviAnimator.gameObject.SetActive(false);
        portraitContentAnimator.gameObject.SetActive(true);

        // Start animation
        cadenasAnimator.Play();
        cadenas.GetComponent<Image>().color = goalReachedColor;
        portraitContentAnimator.Play();

        yield return new WaitForSeconds(2f);

         // Stop animations
        cadenasAnimator.Stop();
        cadenasAnimator.ResetAnimation();
        cadenas.GetComponent<Image>().color = goalLockedColor;
        portraitContentAnimator.Stop();
        portraitContentAnimator.ResetAnimation();
        portraitContentAnimator.gameObject.SetActive(false);
        webcam.portraitSuiviAnimator.gameObject.SetActive(true);

        levelLoader.NextLevel();

        isLevelEnding = false;
    }

    public IEnumerator LevelResetRoutine()
    {
        // Setup
        ManualSpriteAnimator portraitColereAnimator = webcam.portraitColereAnimator;
        webcam.portraitSuiviAnimator.gameObject.SetActive(false);
        portraitColereAnimator.gameObject.SetActive(true);

        // Start animation
        portraitColereAnimator.Play();

        yield return new WaitForSeconds(2f);

         // Stop animations
        portraitColereAnimator.Stop();
        portraitColereAnimator.ResetAnimation();
        portraitColereAnimator.gameObject.SetActive(false);
        webcam.portraitSuiviAnimator.gameObject.SetActive(true);
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

         if(levelLoader.levels[levelLoader.currentLevelIndex].showButtonDecimal)
         {
             switch(button.bitMaskOperator)
        {
            case Operators.AND :
                text = "& " + button.value;
                break;
            case Operators.NAND :
                text = "~& " + button.value;
                break;
            case Operators.OR :
                text = "| " + button.value;
                break;
            case Operators.NOR :
                text = "~| " + button.value;
                break;
            case Operators.XOR :
                text = "^ " + button.value;
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
         }
            else{
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

         }
        buttonText.text = text;
        
    }
    public void PausedGame(bool isPaused)
    {
       
            StopPanel.SetActive(isPaused);
           
        }   



    


    public string ToBinaryString(uint number)
    {
        return Convert.ToString(number, 2).PadLeft(bitLength, '0');
    }
}
