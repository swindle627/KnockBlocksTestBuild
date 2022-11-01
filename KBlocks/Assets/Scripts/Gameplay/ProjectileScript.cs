using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject projectile;
    public Rigidbody rb;
    public Vector3 projectileVelocity;

    private void Start()
    {
        projectile = this.gameObject;
        rb = projectile.GetComponent<Rigidbody>();
        projectileVelocity = rb.velocity;
    }
    // When projectiles collide with objects destroy projectile
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Glass Block")
        {
            Destroy(projectile);
        }
    }
}
