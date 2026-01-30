using UnityEngine;

public class ButtonValueSetter : MonoBehaviour
{
    [System.Serializable]
    public class ButtonConfig
    {
        public NumberButton button;
    }

    public ButtonConfig[] buttons; // taille 4

    public void ApplyLevelData(LevelData levelData)
    {
        buttons[0].button.valueToAdd = levelData.button1Value;
        buttons[1].button.valueToAdd = levelData.button2Value;
        buttons[2].button.valueToAdd = levelData.button3Value;
        buttons[3].button.valueToAdd = levelData.button4Value;
    }
}
