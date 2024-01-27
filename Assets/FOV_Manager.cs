using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class FOV_Manager : MonoBehaviour
    {
        public Camera camDoor;
        public Transform doorObject;
        public Camera MainCam;

        // Adjust these values to control the FOV and rotation
        public float minFOV = 30f;
        public float maxFOV = 180f;
        public float maxDistance = 10f;  // Adjust this value based on your scene

        // Start is called before the first frame update
        void Start()
        {
            if (camDoor == null || doorObject == null || MainCam == null)
            {
                Debug.LogError("Please assign all cameras and door objects in the inspector.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Calculate the distance between MainCam and doorObject
            float distance = Vector3.Distance(MainCam.transform.position, doorObject.position);

            // Map the distance to a FOV value between maxFOV and minFOV
            float fov = Mathf.Lerp(maxFOV, minFOV, Mathf.InverseLerp(0f, maxDistance, distance));

            // Set the FOV of camDoor
            camDoor.fieldOfView = fov;

            // Calculate the rotation between MainCam and doorObject
            Vector3 directionToDoor = doorObject.position - MainCam.transform.position;
            Quaternion rotationToDoor = Quaternion.LookRotation(directionToDoor, Vector3.up);

            // Assign the rotation to doorCam
            camDoor.transform.rotation = rotationToDoor;
        }
    }
}
