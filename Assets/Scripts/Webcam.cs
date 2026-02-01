using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Webcam : MonoBehaviour
{
    public ManualSpriteAnimator portraitSuiviAnimator;
    public ManualSpriteAnimator portraitContentAnimator;
    public ManualSpriteAnimator portraitColereAnimator;

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        float gridX = (int) ((mousePosition.x / Screen.currentResolution.width) * 3);
        float gridY = (int) ((mousePosition.y / Screen.currentResolution.height) * 3);

        // Debug.Log($"x : {gridX} / y : {gridY}");

        if(gridX == 1 && gridY == 1) // Milieu
        {
            portraitSuiviAnimator.SetFrame(0);
        } else if (gridX == 1 && gridY == 2) // Milieu Haut
        {
            portraitSuiviAnimator.SetFrame(1);
        } else if (gridX == 0 && gridY == 2) // Gauche Haut
        {
            portraitSuiviAnimator.SetFrame(2);
        } else if (gridX == 0 && gridY == 1) // Gauche Milieu
        {
            portraitSuiviAnimator.SetFrame(3);
        } else if (gridX == 0 && gridY == 0) // Gauche Bas
        {
            portraitSuiviAnimator.SetFrame(4);
        } else if (gridX == 1 && gridY == 0) // Milieu Bas
        {
            portraitSuiviAnimator.SetFrame(5);
        } else if (gridX == 2 && gridY == 0) // Droite Bas
        {
            portraitSuiviAnimator.SetFrame(6);
        } else if (gridX == 2 && gridY == 1) // Droite Milieu
        {
            portraitSuiviAnimator.SetFrame(7);
        } else if (gridX == 2 && gridY == 2) // Droite Haut
        {
            portraitSuiviAnimator.SetFrame(8);
        }
    }
}
