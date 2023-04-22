using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera Instance;
        public PlayerManager player;
        public Camera cameraObject;
        [SerializeField] Transform cameraPivotTranform;

        [Header("Camera Settings")]
        private float cameraSmoothSpeed = 1.0f;
        [SerializeField] float leftRightLookSpeed = 220;
        [SerializeField] float upDownLookSpeed = 220;
        [SerializeField] float minimumPivot = -30;
        [SerializeField] float maximumPivot = 60;

        [Header("Camera Values")]
        private Vector3 cameraVelocity;
        [SerializeField] float leftRightLookAngle;
        [SerializeField] float upDownLookAngle;

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
        }

        public void HandleAllCameraActions()
        {
            if (player != null)
            {
                HandleFollowTarget();
                HandleRotations();
                // Collide with objects
            }
        }

        private void HandleFollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }

        private void HandleRotations()
        {
            // Normal rotations
            leftRightLookAngle += (PlayerInputManager.Instance.cameraHorizontalInput * leftRightLookSpeed) * Time.deltaTime;
            upDownLookAngle -= (PlayerInputManager.Instance.cameraVerticalInput * upDownLookSpeed) * Time.deltaTime;
            upDownLookAngle = Mathf.Clamp(upDownLookAngle, minimumPivot, maximumPivot);

            Vector3 cameraRotation = Vector3.zero;
            Quaternion targetRotation;

            // Rotate this gameobjects left and right
            cameraRotation.y = leftRightLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            transform.rotation = targetRotation;

            // Rotate this gameobject up and down
            cameraRotation = Vector3.zero;
            cameraRotation.x = upDownLookAngle;
            targetRotation = Quaternion.Euler(cameraRotation);
            cameraPivotTranform.localRotation = targetRotation;
        }
    }
}
