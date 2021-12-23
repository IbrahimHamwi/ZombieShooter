using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET
}
public class WeaponController : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public NameWeapon nameWp;

    protected PlayerAnimations playerAnim;
    protected float lastShot;

    public int gunIndex, currentBullet, bulletMax;

    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;
    }
    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();

                //animate shoot
                playerAnim.AttackAnimation();

                lastShot = Time.time;
                currentBullet--;
            }
            else
            {
                //play no ammo sound
            }

        }
    }// call attack
    public virtual void ProcessAttack()
    {

    }

}
