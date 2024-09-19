using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class WorldCharacterEffectsManager : MonoBehaviour
    {
        public static WorldCharacterEffectsManager Instance;

        [Header("Damage")]
        public TakeHealthDamageEffect takeHealthDamageEffect;

        [SerializeField] List<InstantCharacterEffect> instantEffects;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void GenerateEffectIDs()
        {
            for (int i = 0; i < instantEffects.Count; ++i)
            {
                instantEffects[i].instantEffectID = i;
            }
        }
    }
}

