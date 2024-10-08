using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DU
{
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager Instance;

        [Header("NETWORK JOIN")]
        [SerializeField] bool startGameAsClient;

        public PlayerUIHudManager playerUIHudManager;
        public PlayerUIPopUpManager playerUIPopUpManager;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            playerUIHudManager = GetComponentInChildren<PlayerUIHudManager>();
            playerUIPopUpManager = GetComponentInChildren<PlayerUIPopUpManager>();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (startGameAsClient)
            {
                startGameAsClient = false;
                NetworkManager.Singleton.Shutdown();
                NetworkManager.Singleton.StartClient();
            }
        }
    }

}
