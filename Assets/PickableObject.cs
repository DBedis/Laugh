using UnityEngine;

namespace GGJ
{
    public class PickableObject : MonoBehaviour
    {
        public GameObject pickableObjectsParent; // use it as parent so they stop moving when dropped
        public bool isHoldingobject = false;
        public string pickableTag = "Pickable";
        public float pickRadius = 2f;
        public Transform playerHoldPosition; // Assign this in the inspector to a transform where the objects will be held.

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isHoldingobject)
                {
                    TryPickObject();
                }
                else if (isHoldingobject)
                {
                    Debug.Log("release object ");
                    ReleaseObject();
                    
                }
            }
        }

        private void TryPickObject()
        {
            // Raycasting part
            Camera mainCamera = Camera.main;
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 cameraForward = mainCamera.transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(cameraPosition, cameraForward, out hit, pickRadius))
            {
                PickableObject pickableObject = hit.collider.GetComponent<PickableObject>();
                if (pickableObject != null)
                {
                    // Perform the pick-up action for the raycasted object
                    pickableObject.PickByRaycast(playerHoldPosition);
                    return;
                }
            }

            // Proximity-based picking part
            Collider[] colliders = Physics.OverlapSphere(transform.position, pickRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag(pickableTag))
                {
                    // Perform the pick-up action for the proximity-based object
                    PickByProximity(collider, playerHoldPosition);
                    return;
                }
            }
        }

        private void PickByProximity(Collider collider, Transform holdPosition)
        {
            // Attach the object to the player's hold position and make it a child.
            collider.transform.parent = holdPosition;
            collider.GetComponent<Rigidbody>().isKinematic = true; // Disable the Rigidbody to avoid physics interactions.

            // Optionally, you can perform additional actions such as hiding the object or playing a sound.
            Debug.Log("Picked up (Proximity): " + collider.gameObject.name + " at position: " + collider.transform.position);

            isHoldingobject = true;
        }

        private void PickByRaycast(Transform holdPosition)
        {
            // Attach the object to the player's hold position and make it a child.
            transform.parent = holdPosition;
            GetComponent<Rigidbody>().isKinematic = true; // Disable the Rigidbody to avoid physics interactions.

            // Optionally, you can perform additional actions such as hiding the object or playing a sound.
            Debug.Log("Picked up (Raycast): " + gameObject.name + " at position: " + transform.position);

            isHoldingobject = true;
        }

        void ReleaseObject()
        {
            playerHoldPosition.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            playerHoldPosition.GetChild(0).SetParent(pickableObjectsParent.transform);
            //playerHoldPosition.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            isHoldingobject = false;
        }

    }
}
