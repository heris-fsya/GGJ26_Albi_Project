using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Levels")]
    public List<LevelData> levels = new List<LevelData>();

    [Header("References")]
    public NumberManager numberManager;
    public ButtonValueSetter buttonValueSetter;
    public UIUpdater uiUpdater;
    public DifficultyEventSystem difficultyEventSystem;

    private int currentLevelIndex = 0;

    private void Start()
    {
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int index)
    {
        if (levels == null || levels.Count == 0)
        {
            Debug.LogError("LevelLoader: No levels assigned.");
            return;
        }

        if (index < 0 || index >= levels.Count)
        {
            Debug.LogError("LevelLoader: Invalid level index.");
            return;
        }

        LevelData levelData = levels[index];

        uiUpdater.bitLength = levelData.bitLength;
        numberManager.InitializeLevel(levelData);
        buttonValueSetter.ApplyLevelData(levelData);
        difficultyEventSystem.Configure(levelData.difficulty);
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex >= levels.Count)
        {
            Debug.Log("Last level reached.");
            currentLevelIndex = levels.Count - 1;
            return;
        }

        LoadLevel(currentLevelIndex);
    }

    // (optionnel mais pratique)
    public void RestartLevel()
    {
        LoadLevel(currentLevelIndex);
    }
}

