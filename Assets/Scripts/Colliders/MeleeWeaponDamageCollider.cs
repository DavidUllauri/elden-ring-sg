using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class MeleeWeaponDamageCollider : DamageCollider
    {
        [Header("Attacking Character")]
        public CharacterManager characterCausingDamage;
    }
}
