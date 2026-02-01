using System.Collections.Generic;
using System.Diagnostics;
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
    public Difficulty difficultychoice = Difficulty.NONE; 

    public int currentLevelIndex = 0;



    private void OnEnable()
    {
        UnityEngine.Debug.Log("LevelLoader Enabled");
       FirstStart();
    }
    public void Start()
    {
        UnityEngine.Debug.Log("LevelLoader Start");
      LoadLevel(currentLevelIndex);
    }
    private void OnDisable()
    {
       levels.Clear();
    }


    private void FirstStart()
    {
        levels.Clear();
       
        
            if (difficultychoice == Difficulty.EASY)
            {
                
                levels.AddRange(levelsEasy);
                levels.AddRange(levelsMedium);
                levels.AddRange(levelsHard);

            }
            else if (difficultychoice == Difficulty.MEDIUM)
            {
                levels.AddRange(levelsMedium); 
                levels.AddRange(levelsHard);
            }
            else if (difficultychoice == Difficulty.HARD)
            {
                levels.AddRange(levelsHard);
            }
            else
            {
                 UnityEngine.Debug.Log("No difficulty selected, loading all levels.");
            }
        
         LoadLevel(currentLevelIndex);
        // You can choose levels based on difficulty here if needed
        // For example, to load only easy levels:
        // levels = levelsEasy;
    }

    public void LoadLevel(int index)
    {
        if (levels == null || levels.Count == 0)
        {
             UnityEngine.Debug.Log("LevelLoader: No levels assigned.");
            return;
        }

        if (index < 0 || index >= levels.Count)
        {
            UnityEngine.Debug.Log("LevelLoader: Invalid level index.");
            return;
        }
         uiUpdater.ResetUI();
        LevelData levelData = levels[index];

        uiUpdater.bitLength = levelData.bitLength;
        numberManager.InitializeLevel(levelData);
        buttonValueSetter.ApplyLevelData(levelData);
        difficultyEventSystem.Configure(levelData.difficulty);
        difficultyEventSystem.setAudioClip(levelData.difficulty);
       
        uiUpdater.UpdateUI();
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex >= levels.Count)
        {
             UnityEngine.Debug.Log("Last level reached.");
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

        public void ResetGame()
    {

        currentLevelIndex = 0;

        numberManager.ResetState();
        uiUpdater.ResetUI();
        buttonValueSetter.ResetButtons();
        StopAllCoroutines();
         LoadLevel(currentLevelIndex);
    }

    public void setEasyLevels()
    {
        difficultychoice = Difficulty.EASY;
    }   
    public void setMediumLevels()
    {
        difficultychoice = Difficulty.MEDIUM;
    }
    public void setHardLevels()
    {
        difficultychoice = Difficulty.HARD;
    }
}

