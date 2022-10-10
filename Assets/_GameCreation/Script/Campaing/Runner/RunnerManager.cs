using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : Singleton<RunnerManager>
{
    public Runner runner;
    public void OrderChangeStand()
    {
        runner.ChangeStandState();
    }

    public void GunAttackEnemy()
    {
        runner.ChangeWeaponState(C_WeaponState.Gun);
    }
    public void MelleAttackEnemy()
    {
        runner.ChangeWeaponState(C_WeaponState.Melee);
    }
}
