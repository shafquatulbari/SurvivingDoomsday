using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
        {   
            Application.Quit();
        } 
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
