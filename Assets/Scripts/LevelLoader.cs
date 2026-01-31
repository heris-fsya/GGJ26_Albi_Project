using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelData levelData;

    public NumberManager numberManager;
    public ButtonValueSetter buttonValueSetter;
    public UIUpdater uiUpdater;

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        uiUpdater.bitLength = levelData.bitLength;
        numberManager.InitializeLevel(levelData);
        buttonValueSetter.ApplyLevelData(levelData);
    }
}
