using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberManager : MonoBehaviour
{
    public int currentNumber { get; private set; }
    public int goalNumber { get; private set; }

    public List<int> history = new List<int>();

    public UnityEvent onNumberChanged;

    public void InitializeLevel(LevelData levelData)
    {
        history.Clear();

        goalNumber = levelData.goalNumber;
        currentNumber = levelData.baseNumber;

        history.Add(currentNumber);

        onNumberChanged?.Invoke();
    }

    public void Add(int value)
    {
        currentNumber += value;
        history.Add(currentNumber);
        onNumberChanged?.Invoke();
    }

    public bool IsGoalReached()
    {
        return currentNumber == goalNumber;
    }
}
