using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    bool isPaused;
    private void Start() {
        pauseCanvas.enabled = false;
        isPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {   
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitch>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = true;
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
            FindObjectOfType<WeaponSwitch>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
        }
    }
    public void ContinueGame()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        FindObjectOfType<WeaponSwitch>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
