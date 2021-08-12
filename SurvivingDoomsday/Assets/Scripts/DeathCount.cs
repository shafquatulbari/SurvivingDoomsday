using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    int death = 0;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] Canvas hint2Canvas;
    [SerializeField] Canvas hint1Canvas;

    private void Start() {
        hint2Canvas.enabled = false;  
        hint1Canvas.enabled = true;  
    }

    private void Update() {
        deathText.text = "Kills: " + death + "/15";
        if(death >= 15)
        {
            hint1Canvas.enabled = false;
            hint2Canvas.enabled = true;
            deathText.text = "";
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
