using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DifficultyPopup : MonoBehaviour
{
    public GameObject popupRoot;
    public UIUpdater UiUpdater { get; private set; }

    private void Start()
    {
        UiUpdater = FindObjectOfType<UIUpdater>();
        popupRoot.SetActive(false);
    }

    public void Show()
    {
        popupRoot.SetActive(true);
         UiUpdater.PausedGame(true);
        Time.timeScale = 0f; // optionnel : pause jeu
    }

    public void Hide()
    {
        popupRoot.SetActive(false);
        Time.timeScale = 1f;
        UiUpdater.PausedGame(false);
    }
}
