using UnityEngine;
using System.Collections;  

public class phoneScript : MonoBehaviour
{
    public CapsuleCollider fakeRaycast;
    public GameObject flash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakePicture();
            DoFlash();
        }
    }

    void TakePicture()
    {
        // Check if the fakeRaycast is colliding with an object tagged "sadpicture"
        Collider[] colliders = Physics.OverlapCapsule(
            fakeRaycast.transform.position + fakeRaycast.center + Vector3.up * (fakeRaycast.height * 0.5f - fakeRaycast.radius),
            fakeRaycast.transform.position + fakeRaycast.center - Vector3.up * (fakeRaycast.height * 0.5f - fakeRaycast.radius),
            fakeRaycast.radius, LayerMask.GetMask("Ground"));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("SadPic"))
            {
                // Deactivate the object tagged "sadpicture" that is colliding with fakeRaycast
                collider.gameObject.SetActive(false);
                Debug.Log("Took a picture of a sad picture!");
            }
        }
    }

    void DoFlash()
    {
        StartCoroutine(FlashCoroutine());
    }

    // Coroutine for the flash effect
    private IEnumerator FlashCoroutine()
    {
        // Set flash active for 0.2 seconds
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        // Set flash inactive for 0.2 seconds
        flash.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        // Set flash active for 0.1 seconds
        flash.SetActive(true);
        yield return new WaitForSeconds(0.02f);

        // Set flash inactive
        flash.SetActive(false);
    }

}
