using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void PlayerRunAnimation(bool run)
    {
        anim.SetBool(TagManager.RUN_PARAMETER, run);
    }
    public void AttackAnimation()
    {
        anim.SetTrigger(TagManager.ATTACK_PARAMTER);
    }
    public void SwitchWeaponAnimation(int typeWeapon)
    {
        anim.SetInteger(TagManager.TYPE_WEAPON_PARAMETER, typeWeapon);
        anim.SetTrigger(TagManager.SWITCH_PARAMTER);
    }
    public void Hurt()
    {
        anim.SetTrigger(TagManager.GET_HURT_PARAMETER);
    }
    public void Dead()
    {
        anim.SetTrigger(TagManager.DEAD_PARAMETER);
    }
}
