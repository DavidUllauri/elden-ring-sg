using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    [CreateAssetMenu(menuName = "Character Effects/Instant Effects/Take Health Damage")]

    public class TakeHealthDamageEffect : InstantCharacterEffect
    {
        [Header("Character Causing Damage")]
        public CharacterManager characterCausingDamage;

        [Header("Damage")]
        public float physicalDamage = 0; // In the future will be split into "Standard", "Strike", "Slash", and "Pierce
        public float magicDamage = 0;
        public float fireDamage = 0;
        public float lightningDamage = 0;
        public float holyDamage = 0;

        [Header("Final Damage")]
        private int finalDamageDealt = 0;

        [Header("Poise")]
        public float poiseDamage = 0;
        public bool poiseIsBroken = false;

        [Header("Animation")]
        public bool playDamageAnimation = true;
        public bool manuallySelectDamageAnimation = false;
        public string damageAnimation;

        [Header("Sound FX")]
        public bool willPlayDamageSFX = true;
        public AudioClip elementalDamageSoundFX;

        [Header("Direction Damage Taken From")]
        public float angleHitFrom;
        public Vector3 contactPoint;

        public override void ProcessEffect(CharacterManager character)
        {
            base.ProcessEffect(character);

            if (character.isDead.Value)
            {
                return;
            }

            CalculateDamage(character);
        }

        private void CalculateDamage(CharacterManager character)
        {
            if(!character.IsOwner)
            {
                return;
            }
            
            if (characterCausingDamage != null)
            {
            }

            finalDamageDealt = Mathf.RoundToInt(physicalDamage + magicDamage + fireDamage + lightningDamage + holyDamage);

            if (finalDamageDealt <= 0)
            {
                finalDamageDealt = 1;
            }

            Debug.Log("Final Damage Given: " + finalDamageDealt);

            character.characterNetworkManager.currentHealth.Value -= finalDamageDealt;
        }
    }
}
    
