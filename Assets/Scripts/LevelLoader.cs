using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelData levelData;

    public NumberManager numberManager;
    public ButtonValueSetter buttonValueSetter;

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        numberManager.InitializeLevel(levelData);
        buttonValueSetter.ApplyLevelData(levelData);
    }
}
