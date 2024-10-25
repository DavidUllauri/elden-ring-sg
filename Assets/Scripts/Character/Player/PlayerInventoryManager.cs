using DU;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class PlayerInventoryManager : CharacterInventoryManager
    {
        public WeaponItem currentRightHandWeapon;
        public WeaponItem currentLeftHandWeapon;

        [Header("Quick Slots")]
        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[3];
        public int rightHandWeaponIndex = 0;
        public WeaponItem[] weaponInLeftHandSlots = new WeaponItem[3];
        public int leftHandWeaponIndex = 0;
    }
}
