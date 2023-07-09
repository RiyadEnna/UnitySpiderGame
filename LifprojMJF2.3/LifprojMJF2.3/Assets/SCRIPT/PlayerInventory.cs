using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;

    public SpellItem currentSpell;
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;

    private void Awake(){
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start(){
        weaponSlotManager.LoadWeaponSlot(rightWeapon,false);
        weaponSlotManager.LoadWeaponSlot(leftWeapon,true);
    }

}
