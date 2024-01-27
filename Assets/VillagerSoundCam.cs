using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class VillagerSoundCam : MonoBehaviour
    {

        public List<AudioClip> soundClip;
        int headposition; // 1 normal, 2 looking up, 3 down
        public Transform camTransform;
        [Range(-0.7f, 0.7f)]
        public float mySliderValue;

        // Start is called before the first frame update
        void Start()
        {
            headposition = 1;
        }

        // Update is called once per frame
        void Update()
        {
            checkRotation();
        }

         // Function to trigger the sound
    public void PlaySound()
    {
        if (soundClip != null)
        {
            // Create a new AudioSource component
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            int rng = Random.Range(0, 5);
            // Set the AudioClip to the AudioSource
            audioSource.clip = soundClip[rng];

            // Play the sound
            audioSource.Play();

            // Destroy the AudioSource component after the sound has finished playing
            Destroy(audioSource, soundClip[rng].length);
        }
        else
        {
            Debug.LogError("Sound clip is not assigned!");
        }
    }

    void checkRotation()
    {
        Debug.Log(camTransform.rotation.eulerAngles.x);
        if (camTransform.rotation.x < -mySliderValue && headposition == 1)
        {
            Debug.Log("Sound");
            PlaySound();
            headposition = 2;
        }
        else if (camTransform.rotation.x <= mySliderValue && camTransform.rotation.x >= -mySliderValue && headposition != 1)
        {
            PlaySound();
            headposition = 1;
        }
    }

    }
}
