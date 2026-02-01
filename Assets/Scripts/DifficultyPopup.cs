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
        popupRoot.GetComponent<EventPopupController>().ShowPopup();
       
       
    }

    public void Hide()
    {
      
        Time.timeScale = 1f;
        popupRoot.GetComponent<EventPopupController>().DeactivatePopup();
       
        popupRoot.SetActive(false);
    }
}
