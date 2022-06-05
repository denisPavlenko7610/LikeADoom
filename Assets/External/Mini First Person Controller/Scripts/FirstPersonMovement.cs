using System;
using System.Collections.Generic;
using UnityEngine;

namespace External.Mini_First_Person_Controller.Scripts
{
    public class FirstPersonMovement : MonoBehaviour
    {
        public float speed = 5;

        [Header("Running")] public bool canRun = true;
        public bool IsRunning { get; private set; }
        public float runSpeed = 9;
        public KeyCode runningKey = KeyCode.LeftShift;

        new Rigidbody rigidbody;
        public List<Func<float>> speedOverrides = new();

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            IsRunning = canRun && Input.GetKey(runningKey);
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }

            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed,
                Input.GetAxis("Vertical") * targetMovingSpeed);
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        }
    }
}