using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Settings")]
    public int bitLength;

    [Header("Difficulty")]
    public Difficulty difficulty; // "Facile", "Normal", "Difficile"
    public bool showGoalDecimal; // On / Off pour Binaire / Decimal

    [Header("Numbers")]
    public uint baseNumber;
    public uint goalNumber;

    [Header("Buttons Values")]
    public List<BitMaskButton> buttons;
}

[System.Serializable]
public struct BitMaskButton
{
    public uint value;
    public Operators bitMaskOperator;
}