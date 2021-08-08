using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip attackSound;
    Transform target;
    [SerializeField] float chaseDistance = 15;
    float distanceToPlayer = Mathf.Infinity;
    NavMeshAgent nvm;
    bool isProvoked = false;
    [SerializeField] float turnSpeed = 10f;
    EnemyHealth health;

    void Start()
    {
        nvm = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead() == true)
        {
            enabled = false;
            nvm.enabled = false;
            audioSource.Stop();
        }
        distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        } 
        else if (distanceToPlayer <= chaseDistance){
            isProvoked = true;
        }
        
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void EngageTarget()
    {   
        FaceTarget();
        if(distanceToPlayer >= nvm.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToPlayer <= nvm.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        nvm.SetDestination(target.position);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkingSound);
        }
    }


    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
