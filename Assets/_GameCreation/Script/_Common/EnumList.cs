
#region Campaign
public enum C_MovingState
{
    Walk, 
    Run
}
public enum C_StandState
{
    Stand,
    Crouch
}
public enum C_CombatState
{
    Travel, // Just run or walk, do not engage
    Stealth, // Only engage if enemies found you
    Guard, // Auto patrol and attack all enemies in sight
    ReadyCombat // member currently under player's command
}
public enum C_WeaponState
{
    Gun,
    Melee
}

public enum C_AnimLayer
{
    StandGun,
    CrouchGun,
    StandMelee,
    CrouchMelee
}

#endregion
