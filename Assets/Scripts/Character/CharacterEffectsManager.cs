using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class CharacterEffectsManager : MonoBehaviour
    {
        CharacterManager character;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }

        // Process Instant Effects
        public virtual void ProcessInstantEffect(InstantCharacterEffect effect)
        {
            effect.ProcessEffect(character);
        }

        // Process Timed Effects

        // Process static effects
    }
}
