using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    int death = 0;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] Canvas hintCanvas;

    private void Start() {
        hintCanvas.enabled = false;    
    }

    private void Update() {
        deathText.text = "Kills: " + death + "/15";
        if(death >= 15)
        {
            hintCanvas.enabled = true;
        }
    }
    
    public void IncreaseDeathCount()
    {
        death++;
    }
    public int getDeathCount()
    {
        return death;
    }
}
