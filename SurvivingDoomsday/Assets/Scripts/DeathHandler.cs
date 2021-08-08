using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas deathMessageCanvas;
    private void Start() {
        deathMessageCanvas.enabled = false;
    }
    public void HandleDeath()
    {
        deathMessageCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
