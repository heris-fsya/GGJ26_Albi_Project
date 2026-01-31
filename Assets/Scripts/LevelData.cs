using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Settings")]
    public int bitLength;

    [Header("Difficulty")]
    public string difficulty; // "Facile", "Normal", "Difficile"

    [Header("Numbers")]
    public int baseNumber;
    public int goalNumber;

    [Header("Buttons Values")]
    public List<BitMaskButton> buttons;
}

[System.Serializable]
public struct BitMaskButton
{
    public int valueToAdd;
    public Operators bitMaskOperator;
}