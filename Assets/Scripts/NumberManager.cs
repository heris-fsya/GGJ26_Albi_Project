using System;
using System.Buffers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

public class NumberManager : MonoBehaviour
{
    public uint currentNumber { get; private set; }
    public uint baseNumber { get; private set; }
    public uint goalNumber { get; private set; }
    private uint LastNumber { get; set; }
    public int bitLength { get; private set; }

    public List<uint> history = new List<uint>();

    public UnityEvent onNumberChanged;

    public void InitializeLevel(LevelData levelData)
    {
        history.Clear();

        goalNumber = levelData.goalNumber;
        currentNumber = levelData.baseNumber;
        baseNumber = levelData.baseNumber;

        bitLength = levelData.bitLength;

      //  history.Add(currentNumber);

       onNumberChanged?.Invoke();
    }

    public void Operation(Operators bitMaskOperator, uint value)
    {
        uint nbOfPossibleValues = (uint) Math.Pow(2, this.bitLength); // Ex: 256 for 8 bit, 16 for 4 bits, etc
        LastNumber = currentNumber;
        switch(bitMaskOperator)
        {
            case Operators.AND:
                currentNumber = currentNumber & value;
                break;
            case Operators.NAND:
                currentNumber = ~(currentNumber & value);
                currentNumber = currentNumber % nbOfPossibleValues;
                break;
            case Operators.OR:
                currentNumber = currentNumber | value;
                break;
            case Operators.NOR:
                currentNumber = ~(currentNumber | value);
                currentNumber = currentNumber % nbOfPossibleValues;
                break;
            case Operators.XOR:
                currentNumber = currentNumber ^ value;
                break;
            case Operators.INVERT:
                currentNumber = ~currentNumber;
                currentNumber = currentNumber % nbOfPossibleValues;
                break;
            case Operators.SHIFTLEFT:
                currentNumber = currentNumber << (int) value;
                currentNumber = currentNumber % nbOfPossibleValues;
                break;
            case Operators.SHIFTRIGHT:
                currentNumber = currentNumber >> (int) value;
                break;
        }

        history.Add(LastNumber);
        onNumberChanged?.Invoke();
    }

    public bool IsGoalReached()
    {
        return currentNumber == goalNumber;
    }
}
