using System;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public NumberManager numberManager;
    private TMP_Text buttonText;

    public uint value;
    
    public Operators bitMaskOperator;

    void OnEnable()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
    }

    public void Init(uint value, Operators bitMaskOperator)
    {
        this.value = value;
        this.bitMaskOperator = bitMaskOperator;
        this.gameObject.SetActive(true);
    }

    public void OnButtonPressed()
    {
        numberManager.Operation(bitMaskOperator, value);
    }
}
