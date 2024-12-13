using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment25
{
    public class TreasureBox : MonoBehaviour
    {
        public Transform lid;
        public Transform glowingOrb;
        public Light pointLight;
        public Vector3 orbOpenOffset = new Vector3(0, 0.5f, 0);
        public float openAngle = 90f;
        public float openSpeed = 2f;
        public float orbMoveSpeed = 2f;
        private bool isOpen = false;
        private Vector3 orbStartPosition;
        private Vector3 orbTargetPosition;
        public ParticleSystem sparkleEffect;
        public ParticleSystem sparkleEffect1;

        void Start()
        {
            // orb`s starting position
            orbStartPosition = glowingOrb.position;
        }
        // Update is called once per frame
        void Update()
        {
            // Check for user interaction to toggle the box state 
            if (Input.GetMouseButtonDown(0))
            {
                ToggleBox();
            }

            // Animate the lid opening and closing
            float targetAngle = isOpen ? openAngle : 0;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            lid.localRotation = Quaternion.Lerp(lid.localRotation, targetRotation, Time.deltaTime * openSpeed);

            // Update the target position for the orb
            orbTargetPosition = isOpen ? orbStartPosition + orbOpenOffset : orbStartPosition;
            // Smoothly move the orb to its target position
            glowingOrb.position = Vector3.Lerp(glowingOrb.position, orbTargetPosition, Time.deltaTime * orbMoveSpeed);

            // Start and stop the sparkles effect
            if (isOpen && !sparkleEffect.isPlaying && !sparkleEffect1.isPlaying)
            {
                sparkleEffect.Play();
                sparkleEffect1.Play();
            }
            else if (!isOpen && sparkleEffect.isPlaying && sparkleEffect1.isPlaying)
            {
                sparkleEffect.Stop();
                sparkleEffect1.Stop();
            }

            // smoothy adjust the light intensity
            float targetIntensity = isOpen ? 3f : 0;
            pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetIntensity, Time.deltaTime * openSpeed);
        }

        // Toggle the state of the box
        void ToggleBox()
        {
            isOpen = !isOpen;
        }
    }
}