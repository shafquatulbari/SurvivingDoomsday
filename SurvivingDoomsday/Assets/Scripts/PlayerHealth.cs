using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 200f;
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    public void IncreaseHealth(float healthIncrease)
    {
        hitPoints += healthIncrease;
    }
    public float GetPlayerHealth()
    {
        return hitPoints;
    }
    
}
