using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerControl : MonoBehaviour
{
    public MemberController mem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                mem.ChaseOrder(hit.point);
            }
        }
    }
}
