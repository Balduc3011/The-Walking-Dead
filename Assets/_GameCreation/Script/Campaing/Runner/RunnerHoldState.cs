using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerHoldState : State<Runner>
{
    public override void Enter(Runner go)
    {
        //throw new System.NotImplementedException();
    }

    public override void Execute(Runner go)
    {
        //throw new System.NotImplementedException();
        go.HoldPosition();
        go.weaponCoolDown -= Time.deltaTime;
        if (go.weaponCoolDown <= 0f)
        {
            go.weaponCoolDown = 2f;
            Collider[] hitColliders = Physics.OverlapSphere(go.transform.position, 15f, go.enemyLayer);
            foreach (var hitCollider in hitColliders)
            {
                go.transform.LookAt(hitCollider.transform);
                go.animator.SetTrigger("Attack");
            }
        }
    }

    public override void Exit(Runner go)
    {
        //throw new System.NotImplementedException();
    }
}
