using UnityEngine;

public class PausePopUp : MonoBehaviour
{
    [SerializeField] GameObject popUp;


    public void PopUpSetActive(bool active) //Button OnClick
    {
        popUp.SetActive(active);
        Time.timeScale = active ? 0.0f : 1.0f;
    }

    public void ExitGame() //Button OnClick
    {
        Application.Quit();
    }

    public bool IsPaused()
    {
        return popUp.activeSelf;
    }
}
