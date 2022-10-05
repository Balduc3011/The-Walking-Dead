using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerControl : Singleton<CPlayerControl>
{
    public MemberController selectedMember;
    bool doubleClickWait;
    float doubleClickCounter;
    [SerializeField]
    float doubleClickCooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doubleClickWait)
        {
            doubleClickCounter += Time.deltaTime;
            if (doubleClickCounter >= doubleClickCooldown)
            {
                doubleClickCounter = 0;
                doubleClickWait = false;
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(doubleClickWait)
                {
                    selectedMember.ChaseOrder(hit.point);
                }
                else
                {
                    selectedMember.MoveOrder(hit.point);
                }
                doubleClickWait = true;
                doubleClickCounter = 0;
            }
        }
    }

    public void OrderChangeStand()
    {
        // Call memberControler to change stand
    }
}
