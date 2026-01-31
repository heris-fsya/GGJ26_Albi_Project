using System.Collections.Generic;
using UnityEngine;

public class ButtonValueSetter : MonoBehaviour
{
    public List<NumberButton> buttons;

    public void ApplyLevelData(LevelData levelData)
    {
        for(int i = 0; i < levelData.buttons.Count && i < 6; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].valueToAdd = levelData.buttons[i].valueToAdd;
            buttons[i].bitMaskOperator = levelData.buttons[i].bitMaskOperator;
        }
    }
}
