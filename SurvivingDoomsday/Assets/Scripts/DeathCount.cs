using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    int death = 0;
    [SerializeField] TextMeshProUGUI deathText;
    private void Update() {
        deathText.text = "Kills: " + death + "/15";
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
