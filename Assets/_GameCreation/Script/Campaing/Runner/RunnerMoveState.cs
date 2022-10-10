using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMoveState : State<Runner>
{
    public override void Enter(Runner go)
    {
        //throw new System.NotImplementedException();
        //go.HoldPosition();
        go.agent.SetDestination(go.destination);
        switch (go.standState)
        {
            case C_StandState.Stand:
                switch (go.movingState)
                {
                    case C_MovingState.Walk:
                        go.agent.speed = 4f;
                        break;
                    case C_MovingState.Run:
                        go.agent.speed = 8f;
                        break;
                    default:
                        break;
                }
                break;
            case C_StandState.Crouch:
                go.agent.speed = 2f;
                go.movingState = C_MovingState.Walk;
                break;
            default:
                break;
        }
    }

    public override void Execute(Runner go)
    {
        //throw new System.NotImplementedException();
        go.pointer.position = go.transform.position;
        if (!go.agent.pathPending)
        {
            if (go.agent.remainingDistance <= go.agent.stoppingDistance)
            {
                if (!go.agent.hasPath || go.agent.velocity.sqrMagnitude == 0f)
                {
                    go.StateMachine.ChangeState(go.runnerHoldState);
                }
            }
        }
        if (go.agent.remainingDistance > go.agent.stoppingDistance)
        {
            go.animator.SetBool(go.movingState.ToString(), true);
        }
    }

    public override void Exit(Runner go)
    {
        //throw new System.NotImplementedException();
    }

}
