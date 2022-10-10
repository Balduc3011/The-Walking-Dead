using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public float totalHealth;
    public float currentHealth;

    public virtual void Start()
    {
        InitChar();
    }
    public void InitChar()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        else
        {
            gameObject.AddComponent<NavMeshAgent>();
            agent = GetComponent<NavMeshAgent>();
            agent.radius = 0.3f;
        }
        if (GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
    }
}
