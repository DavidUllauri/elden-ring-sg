using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU 
{
    public class WorldSoundFXManager : MonoBehaviour
    {
        public static WorldSoundFXManager Instance;

        [Header("Action Sound")]
        public AudioClip rollSFX;

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

        // Update is called once per frame
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
