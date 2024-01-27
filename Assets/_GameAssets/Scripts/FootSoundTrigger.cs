using UnityEngine;

namespace GGJ
{
    public class FootSoundTrigger : MonoBehaviour
    {
        public AudioSource footSteps;
        public float normalSpeedRate = 0.5f;
        public float runningSpeedRate = 0.2f;

        private void Update()
        {
            if (transform.GetComponent<CharacterController>().velocity != Vector3.zero)
            {
                float m = transform.GetComponent<CharacterController>().velocity.magnitude;
                if (m < 5)
                {
                    Invoke("FootTrigger", normalSpeedRate);

                }
                else if (m > 5)
                {
                    Invoke("FootTrigger", runningSpeedRate);
                }
            }
        }
        public void FootTrigger()
        {
            if (footSteps != null)
                footSteps.Play();

        }
    }
}
