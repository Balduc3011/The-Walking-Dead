using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MemberController : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator animator;
    public Transform pointer;

    void Start()
    {
        InitMember();
    }
    public void InitMember()
    {
        if(GetComponent<NavMeshAgent>() != null)
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

    // Update is called once per frame
    void Update()
    {
        pointer.position = transform.position;
        if(agent.remainingDistance <= 0.3f)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                animator.SetBool("Walk", false);
                HoldPosition();
            }
        }
        else
        {
            animator.SetBool("Walk", true);
        }
        
    }

    public void HoldPosition()
    {
        agent.speed = 4;
    }
    
    public void MoveOrder(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void ChaseOrder(Vector3 destination)
    {
        agent.speed = 12;
        agent.SetDestination(destination);
    }
}
