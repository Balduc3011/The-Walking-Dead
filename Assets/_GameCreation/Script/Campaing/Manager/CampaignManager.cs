using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignManager : Singleton<CampaignManager>
{
    public InputManager inputManager;
    void Awake()
    {
        inputManager = new InputManager();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.Update();
    }
}
