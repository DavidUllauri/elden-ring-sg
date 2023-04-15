using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DU
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        PlayerManager player;

        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;

        private Vector3 moveDirection;
        [SerializeField]public float walkingSpeed = 2;
        [SerializeField] public float runningSpeed = 5;

        protected override void Awake()
        {
            base.Awake();

            player = GetComponent<PlayerManager>();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            // AERIAL MOVEMENT
        }

        private void GetVerticalAndHorizontalInputs()
        {
            verticalMovement = PlayerInputManager.Instance.verticalInput;
            horizontalMovement = PlayerInputManager.Instance.horizontalInput;

            // Clamp the movements
        }

        private void HandleGroundedMovement()
        {
            GetVerticalAndHorizontalInputs();

            // Our move direction is based on our cameras faceing perspective.
            moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
            moveDirection = moveDirection + PlayerCamera.instance.transform.right * horizontalMovement;
            moveDirection.Normalize();
            moveDirection.y = 0;

            if (PlayerInputManager.Instance.moveAmount > 0.5f) // Move at running speed
            {
                player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
            }
            else if (PlayerInputManager.Instance.moveAmount <= 0.5f) // Move at walking speed
            {
                player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
            }
        }
    }
}
