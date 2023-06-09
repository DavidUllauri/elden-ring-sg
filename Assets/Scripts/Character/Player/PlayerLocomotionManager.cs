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
        private Vector3 targetRotationDirection;
        [SerializeField]public float walkingSpeed = 2;
        [SerializeField] public float runningSpeed = 5;
        [SerializeField] public float rotationSpeed = 5;

        protected override void Awake()
        {
            base.Awake();

            player = GetComponent<PlayerManager>();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
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
            moveDirection = PlayerCamera.Instance.transform.forward * verticalMovement;
            moveDirection = moveDirection + PlayerCamera.Instance.transform.right * horizontalMovement;
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

        private void HandleRotation()
        {
            targetRotationDirection = Vector3.zero;
            targetRotationDirection = PlayerCamera.Instance.cameraObject.transform.forward * verticalMovement;
            targetRotationDirection += PlayerCamera.Instance.cameraObject.transform.right * horizontalMovement;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            if (targetRotationDirection == Vector3.zero)
            {
                targetRotationDirection = transform.forward;
            }

            Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
    }
}
