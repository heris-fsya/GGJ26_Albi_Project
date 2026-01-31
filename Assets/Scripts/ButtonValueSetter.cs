using System.Collections.Generic;
using UnityEngine;

public class ButtonValueSetter : MonoBehaviour
{
    public UIUpdater uiUpdater;
    public List<NumberButton> buttons;

    public void ApplyLevelData(LevelData levelData)
    {
        for(int i = 0; i < levelData.buttons.Count && i < 8; i++)
        {
            buttons[i].Init(levelData.buttons[i].valueToAdd, levelData.buttons[i].bitMaskOperator);
            uiUpdater.UpdateButtonText(buttons[i]);
        }
    }
}
