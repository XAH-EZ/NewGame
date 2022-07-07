using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : Menu
{
    
    public override void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("Menu");
    }
}
