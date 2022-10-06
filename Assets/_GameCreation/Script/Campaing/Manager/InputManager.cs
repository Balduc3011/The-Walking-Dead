using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    bool doubleClickWait;
    float doubleClickCounter;
    [SerializeField]
    float doubleClickCooldown = 0.4f;

    // Update is called once per frame
    public void Update()
    {
        if (doubleClickWait)
        {
            doubleClickCounter += Time.deltaTime;
            if (doubleClickCounter >= doubleClickCooldown)
            {
                doubleClickCounter = 0;
                doubleClickWait = false;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (doubleClickWait)
                {
                    CPlayerControl.Instance.selectedMember.ChaseOrder(hit.point);
                }
                else
                {
                    CPlayerControl.Instance.selectedMember.MoveOrder(hit.point);
                }
                doubleClickWait = true;
                doubleClickCounter = 0;
            }
        }
    }
}
