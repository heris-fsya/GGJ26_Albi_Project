using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Numbers")]
    public int baseNumber;
    public int goalNumber;

    [Header("Buttons Values")]
    public int button1Value;
    public int button2Value;
    public int button3Value;
    public int button4Value;
}
