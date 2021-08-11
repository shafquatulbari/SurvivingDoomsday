using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] float damage = 20f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void TargetAttacked()
    {
        if(target == null) return;
        target.TakeDamage(damage);
        hitEffect.Play();
    }

}
