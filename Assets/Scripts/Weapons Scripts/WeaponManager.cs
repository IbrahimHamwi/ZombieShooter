using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weapon_Unlocked;
    public WeaponController[] total_Weapons;

    [HideInInspector]
    public WeaponController current_Weapon;
    private int current_Weapon_Index;

    private TypeControlAttack current_Type_Control;
    private PlayerArmController[] armController;
    private PlayerAnimations playerAnim;
    private bool isShooting;

    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();

        LoadActiveWeapons();

        current_Weapon_Index = 1;
    }

    void Start()
    {
        armController = GetComponentsInChildren<PlayerArmController>();
        // set the first weapon to be pistol
        ChangeWeapon(weapon_Unlocked[1]);
        playerAnim.SwitchWeaponAnimation((int)weapon_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
    }
    void LoadActiveWeapons()
    {
        weapon_Unlocked.Add(total_Weapons[0]);
        for (int i = 1; i < total_Weapons.Length; i++)
        {
            weapon_Unlocked.Add(total_Weapons[i]);
        }
    }
    public void SwitchWeapon()
    {
        current_Weapon_Index++;
        current_Weapon_Index = (current_Weapon_Index >= weapon_Unlocked.Count) ? 0 : current_Weapon_Index;

        playerAnim.SwitchWeaponAnimation((int)weapon_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
        ChangeWeapon(weapon_Unlocked[current_Weapon_Index]);
    }
    void ChangeWeapon(WeaponController newWeapon)
    {
        if (current_Weapon)
            current_Weapon.gameObject.SetActive(false);

        current_Weapon = newWeapon;
        current_Type_Control = newWeapon.defaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

        if (newWeapon.defaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < armController.Length; i++)
            {
                armController[i].ChangeToTwoHand();
            }
        }
        else
        {
            for (int i = 0; i < armController.Length; i++)
            {
                armController[i].ChangeToOneHand();
            }
        }
    }
    public void Attack()
    {
        if (current_Type_Control == TypeControlAttack.Hold)
        {
            current_Weapon.CallAttack();
        }
        else if (current_Type_Control == TypeControlAttack.Click)
        {
            if (!isShooting)
            {
                current_Weapon.CallAttack();
                isShooting = true;
            }
        }
    }
    public void ResetAttack()
    {
        isShooting = false;
    }
}
