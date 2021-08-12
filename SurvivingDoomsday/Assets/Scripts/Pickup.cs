using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] float healthAmount = 40;
    [SerializeField] AmmoType ammoType;
    
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && gameObject.tag == "Health")
        {
            if(FindObjectOfType<PlayerHealth>().GetPlayerHealth() <= 400)
            {
                FindObjectOfType<PlayerHealth>().IncreaseHealth(healthAmount);
                Destroy(gameObject);
            }
        }
        else if(other.gameObject.tag == "Player" && gameObject.tag == "Ammo")
        {
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType,ammoAmount);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && gameObject.tag == "SpaceShip"
        && FindObjectOfType<DeathCount>().getDeathCount() >= 15)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if(other.gameObject.tag == "Player" && gameObject.tag == "Boundary")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
