using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Runner : Character
{    
    public Transform pointer;
    // State Machine
    [Header("State Machine")]
    public RunnerHoldState runnerHoldState = new RunnerHoldState();
    public RunnerMoveState runnerMoveState = new RunnerMoveState();
    public StateMachine<Runner> StateMachine { get { return m_StateMachine; } }
    protected StateMachine<Runner> m_StateMachine;

    [Header("State Runner")]
    public C_MovingState movingState;
    public C_StandState standState;
    public C_CombatState combatState;
    public C_WeaponState weaponState;
    public Vector3 destination;
    public BoxCollider boxCollider;

    [Header("Combat parameter")]
    public LayerMask enemyLayer;
    public float weaponDamage;
    public float weaponRange;
    public float weaponCoolDown;
    

    public override void Start()
    {
        base.Start();
        m_StateMachine = new StateMachine<Runner>(this);
        m_StateMachine.SetCurrentState(runnerHoldState);
    }
    

    void Update()
    {
        m_StateMachine.Update();
    }

    public void ChangeStandState()
    {
        switch (standState)
        {
            case C_StandState.Stand:
                standState = C_StandState.Crouch;
                boxCollider.center = new Vector3(0f, 0.5f, 0f);
                boxCollider.size = new Vector3(0.5f, 1f, 0.5f);
                break;
            case C_StandState.Crouch:
                standState = C_StandState.Stand;
                boxCollider.center = new Vector3(0f, 1f, 0f);
                boxCollider.size = new Vector3(0.5f, 2f, 0.5f);
                break;
            default:
                standState = C_StandState.Stand;
                break;
        }
        ChangeStand();
    }
    public void ChangeWeaponState(C_WeaponState weaponStateToChange)
    {
        weaponState = weaponStateToChange;
        ChangeStand();
    }
    public void ChangeStand()
    {
        switch (standState)
        {
            case C_StandState.Stand:
                switch (weaponState)
                {
                    case C_WeaponState.Gun:
                        ChangeAnimLayer(C_AnimLayer.StandGun);
                        break;
                    case C_WeaponState.Melee:
                        ChangeAnimLayer(C_AnimLayer.StandMelee);
                        break;
                    default:
                        ChangeAnimLayer(C_AnimLayer.StandGun);
                        break;
                }
                break;
            case C_StandState.Crouch:
                switch (weaponState)
                {
                    case C_WeaponState.Gun:
                        ChangeAnimLayer(C_AnimLayer.CrouchGun);
                        break;
                    case C_WeaponState.Melee:
                        ChangeAnimLayer(C_AnimLayer.CrouchMelee);
                        break;
                    default:
                        ChangeAnimLayer(C_AnimLayer.CrouchGun);
                        break;
                }
                break;
            default:
                ChangeAnimLayer(C_AnimLayer.StandGun);
                break;
        }
        MoveOrder(destination);
    }

    public void ChangeAnimLayer(C_AnimLayer layer)
    {
        string[] EnumNames = System.Enum.GetNames(typeof(C_AnimLayer));
        for (int i = 0; i < EnumNames.Length; i++)
        {
            animator.SetLayerWeight(i+1, 0);
            if(layer.ToString() == EnumNames[i])
            {
                animator.SetLayerWeight(i + 1, 1);
            }
        }
    }

    public void HoldPosition()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }

    public void MoveOrder(Vector3 destinationToGo)
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
        movingState = C_MovingState.Walk;
        destination = destinationToGo;
        m_StateMachine.ChangeState(runnerMoveState);
    }

    public void ChaseOrder(Vector3 destinationToGo)
    {
        animator.SetBool("Run", true);
        animator.SetBool("Walk", false);
        movingState = C_MovingState.Run;
        destination = destinationToGo;
        m_StateMachine.ChangeState(runnerMoveState);
    }

    public void EndAttack()
    {
        animator.ResetTrigger("Attack");
    }
}
