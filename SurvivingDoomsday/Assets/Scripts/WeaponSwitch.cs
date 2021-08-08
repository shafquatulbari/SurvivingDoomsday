using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int prevWeapon = currentWeapon;
        ProcessKeyIn();
        if(prevWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyIn()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        } 
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        
    }
}
