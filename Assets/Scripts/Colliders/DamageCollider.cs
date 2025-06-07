using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class DamageCollider : MonoBehaviour
    {
        [Header("Collider")]
        [SerializeField] protected Collider damageCollider;

        [Header("Damage")]
        public float physicalDamage = 0; // In the future will be split into "Standard", "Strike", "Slash", and "Pierce
        public float magicDamage = 0;
        public float fireDamage = 0;
        public float lightningDamage = 0;
        public float holyDamage = 0;

        [Header("Contact Point")]
        protected Vector3 contactPoint;

        [Header("Characters Damaged")]
        protected List<CharacterManager> charactersDamaged = new List<CharacterManager>();

        protected virtual void Awake()
        {

        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            CharacterManager damageTarget = other.GetComponentInParent<CharacterManager>();

            if (damageTarget != null)
            {
                contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

                DamageTarget(damageTarget);
            }
        }

        protected virtual void DamageTarget(CharacterManager damageTarget)
        {
            if (charactersDamaged.Contains(damageTarget))
            {
                return;
            }

            charactersDamaged.Add(damageTarget);

            TakeDamageEffect healthDamageEffect = Instantiate(WorldCharacterEffectsManager.Instance.takeDamageEffect);
            healthDamageEffect.physicalDamage = physicalDamage;
            healthDamageEffect.magicDamage = magicDamage;
            healthDamageEffect.fireDamage = fireDamage;
            healthDamageEffect.holyDamage = holyDamage;
            healthDamageEffect.contactPoint = contactPoint;

            damageTarget.characterEffectsManager.ProcessInstantEffect(healthDamageEffect);
        }

        public virtual void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public virtual void DisableDamageCollider()
        {
            damageCollider.enabled = false;
            charactersDamaged.Clear();
        }
    }
}
