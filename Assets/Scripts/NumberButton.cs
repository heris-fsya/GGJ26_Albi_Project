using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public NumberManager numberManager;

    public int valueToAdd;
    
    public Operators bitMaskOperator;

    public void OnButtonPressed()
    {
        numberManager.Add(valueToAdd);
    }
}
