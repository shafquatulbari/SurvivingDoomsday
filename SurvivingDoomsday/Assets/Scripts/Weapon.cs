using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioClip attackSoundPlayer;
    AudioSource audioSource;
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float weaponDamage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot = true;
    [SerializeField] float timeDiffOfShots = 0.5f;
    private void OnEnable() {
        canShoot = true;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(ShootBullets());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator ShootBullets()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(attackSoundPlayer);
            }
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
        yield return new WaitForSeconds(timeDiffOfShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position
        , firstPersonCamera.transform.forward, out hit, weaponRange))
        {
            CreateHitEffect(hit);
            //hit effect for visual feedback and call method to decrease enemy health
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return; // for null reference
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
