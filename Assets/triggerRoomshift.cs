using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class triggerRoomshift : MonoBehaviour
    {
        public RoomsManager RM_Instance;
        public int roomPosition;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Adjust the tag as needed
            {
                RM_Instance.SetLocation(roomPosition); // Assuming you have 'roomPosition' defined somewhere
            }
        }
    }
}
