using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DU
{
    public class WorldItemDatabase : MonoBehaviour
    {
        public static WorldItemDatabase Instance { get; private set; }

        public WeaponItem unarmedWeapon;

        [Header("Weapons")]
        [SerializeField] List<WeaponItem> weapons = new List<WeaponItem>();

        [Header("Items")]
        private List<Item> items = new List<Item>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
            } 
            else
            {
                Instance = this;
            }

            foreach (var weapon in weapons)
            {
                items.Add(weapon);
            }

            for (int i = 0; i < items.Count; i++)
            {
                items[i].itemID = i;
            }
        }

        public WeaponItem GetWeaponByID(int idx)
        {
            //return weapons.FirstOrDefault(weapon => weapon.itemID == idx);
            return weapons[idx];
        }
    }
}
