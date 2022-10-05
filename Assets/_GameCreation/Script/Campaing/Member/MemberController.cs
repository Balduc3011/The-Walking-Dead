using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MemberController : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator animator;
    public C_MovingState movingState;
    public Transform pointer;

    public float weaponCoolDown;
    public LayerMask enemyLayer;

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
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    HoldPosition();
                    weaponCoolDown -= Time.deltaTime;
                    if (weaponCoolDown <= 0f)
                    {
                        weaponCoolDown = 2f;
                        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 15f, enemyLayer);
                        foreach (var hitCollider in hitColliders)
                        {
                            transform.LookAt(hitCollider.transform);
                            animator.SetTrigger("Attack");
                        }
                    }
                }
            }
        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            animator.SetBool(movingState.ToString(), true);   
        }
    }

    public void HoldPosition()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }
    
    public void MoveOrder(Vector3 destination)
    {
        HoldPosition();
        agent.speed = 4;
        movingState = C_MovingState.Walk;
        agent.SetDestination(destination);
    }

    public void ChaseOrder(Vector3 destination)
    {
        HoldPosition();
        agent.speed = 8;
        movingState = C_MovingState.Run;
        agent.SetDestination(destination);
    }

    public void EndAttack()
    {
        animator.ResetTrigger("Attack");
    }
}
