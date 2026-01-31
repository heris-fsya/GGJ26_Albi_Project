using System;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public NumberManager numberManager;
    private TMP_Text buttonText;

    public int valueToAdd;
    
    public Operators bitMaskOperator;

    void OnEnable()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
    }

    public void Init(int value, Operators bitMaskOperator)
    {
        this.valueToAdd = value;
        this.bitMaskOperator = bitMaskOperator;
        this.gameObject.SetActive(true);
    }

    public void OnButtonPressed()
    {
        numberManager.Add(valueToAdd);
    }
}
