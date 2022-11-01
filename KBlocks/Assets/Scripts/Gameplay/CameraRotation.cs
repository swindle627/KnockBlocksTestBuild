using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Transform cam;
    private Transform rotationPoint;
    private float rotationSpeed = 15;
    private string moveDirection = "";

    private void Start()
    {
        cam = this.gameObject.transform;
        rotationPoint = GameObject.Find("Rotation Point").GetComponent<Transform>();
        cam.position = new Vector3(-10.74f, 6.84f, -15.18f);
        cam.eulerAngles = new Vector3(21.3f, 35.4f, 1f);
    }
    // Camera movement smoothened out due to fixed update
    private void FixedUpdate()
    {
        //transform.LookAt(rotationPoint);
        if (moveDirection == "left")
        {
            RotateLeft();
        }
        if(moveDirection == "right")
        {
            RotateRight();
        }
    }
    // Called when rotate left button is pressed
    public void OnLeftPress()
    {
        moveDirection = "left";
    }
    // Called when rotate left button is released
    public void OnLeftRelease()
    {
        moveDirection = "";
    }
    // Called when rotate right button is pressed
    public void OnRightPress()
    {
        moveDirection = "right";
    }
    // Called when rotate right button is released
    public void OnRightRelease()
    {
        moveDirection = "";
    }
    // Rotates camera right
    public void RotateRight()
    {
        transform.LookAt(rotationPoint);
        cam.Translate(Vector3.right * Time.fixedDeltaTime * rotationSpeed);
    }
    // Rotates camera left
    private void RotateLeft()
    {
        transform.LookAt(rotationPoint);
        cam.Translate(Vector3.left * Time.fixedDeltaTime * rotationSpeed);
    }
}
