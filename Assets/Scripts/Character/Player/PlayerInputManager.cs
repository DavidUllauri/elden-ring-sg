using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DU
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager Instance;
        PlayerControls playerControls;

        [SerializeField] Vector2 movementInput;

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

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.activeSceneChanged += OnSceneChange;

            Instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            if (newScene.buildIndex == WorldSaveGameManager.Instance.GetWorldSceneIndex())
            {
                Instance.enabled = true;
            }
            else
            {
                Instance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }
    }
}
