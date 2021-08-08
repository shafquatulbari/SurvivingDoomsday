using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] GameObject player;
    private void Update() {
        slider.value = player.GetComponent<PlayerHealth>().GetPlayerHealth();
    }
}
