using TMPro;
using UnityEngine;

public class DifficultyText : MonoBehaviour
{
    private TMP_Text text;

    public Color easyColor;
    public Color mediumColor;
    public Color hardColor;

    public void SetColor(Difficulty difficulty)
    {
        if(!text) text = GetComponent<TMP_Text>();

        switch(difficulty)
        {
            case Difficulty.EASY:
                text.text = "Easy";
                text.color = easyColor;
                break;
            case Difficulty.MEDIUM:
                text.text = "Medium";
                text.color = mediumColor;
                break;
            case Difficulty.HARD:
                text.text = "Hard";
                text.color = hardColor;
                break;
        }
    }
}
