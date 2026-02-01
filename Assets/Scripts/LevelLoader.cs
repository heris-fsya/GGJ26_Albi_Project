using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Levels")]
    public List<LevelData> levels = new List<LevelData>();
    public List<LevelData> levelsEasy = new List<LevelData>();
    public List<LevelData> levelsMedium = new List<LevelData>();
    public List<LevelData> levelsHard = new List<LevelData>();
    //public List<LevelData> levelsExtrem = new List<LevelData>();

    [Header("References")]
    public NumberManager numberManager;
    public ButtonValueSetter buttonValueSetter;
    public UIUpdater uiUpdater;
    public DifficultyEventSystem difficultyEventSystem;


    public int currentLevelIndex = 0;
private void Awake()
    {
        // You can choose levels based on difficulty here if needed
        // For example, to load only easy levels:
        // levels = levelsEasy;
    }
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
        difficultyEventSystem.setAudioClip(levelData.difficulty);
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

    public void RestartLevel()
    {
        StartCoroutine(uiUpdater.LevelResetRoutine());
        LoadLevel(currentLevelIndex);
    }
}

