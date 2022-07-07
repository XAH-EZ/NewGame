using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject convasControls;
    public GameObject pausePanel;
    public void StartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void ControlButton()
    {
        convasControls.SetActive(true);
        if(pausePanel != null)
        pausePanel.SetActive(false);
    }
    public void CloseButton()
    {
        convasControls.SetActive(false);
        if(pausePanel != null)
        pausePanel.SetActive(true);
    }
    public virtual void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void ContinueBotton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    // public void MenuButton()
    // {
    //     SceneManager.LoadScene(0);
    // }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
