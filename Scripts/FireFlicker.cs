using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment25
{
    public class FireFliker : MonoBehaviour
    {
        public Light fireLight;
        public float minIntensity = 2f;
        public float maxIntensity = 4f;
        public float flickerSpeed = 0.1f;
        private float targetIntensity;

        // Start is called before the first frame update
        void Start()
        {
            // set the initial target intensity
            targetIntensity = fireLight.intensity;
        }

        // Update is called once per frame
        void Update()
        {
            // Gradually adjust the light intensity toward the target
            fireLight.intensity = Mathf.Lerp(fireLight.intensity, targetIntensity, Time.deltaTime * flickerSpeed);
            // Randomly change the target intensity
            if (Mathf.Abs(fireLight.intensity - targetIntensity) < 0.1)
            {
                targetIntensity = Random.Range(minIntensity, maxIntensity);
            }
        }
    }
}