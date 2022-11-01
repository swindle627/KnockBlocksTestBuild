using UnityEngine;

public class DeletionPlane : MonoBehaviour
{
    // When object touches the deletion plane its deleted
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Scenery")
        {
            Destroy(collision.gameObject);
        }
    }
}
