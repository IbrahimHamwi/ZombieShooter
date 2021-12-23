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
        playerAnim.SwitchWeaponAnimation((int)weapon_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
    }
    void Update()
    {

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
        current_Weapon_Index %= weapon_Unlocked.Count;

        playerAnim.SwitchWeaponAnimation((int)weapon_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
    }
    //Change Weapon();

}
