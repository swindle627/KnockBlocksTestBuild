using UnityEngine;

public class ExplosionBlock : MonoBehaviour
{
    [Header("Block VFX")]
    public ParticleSystem explosionEffect;

    [Header("Explosion settings")]
    public float explosionRadius;
    public float explosionStrength;
    public float lightBlockExplosionStrength;
    public float upwardsForce;
    public ForceMode forceMode;
    
    private BlockTracker platform;
    private float currExplosionStrength; // explosion strebgth will be adjusted by block

    private void Awake()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<BlockTracker>();
    }
    // If block is in the platfom space (trigger collider) then it will be added to the block list
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Platform Object")
        {
            platform.AddToList(this.gameObject);
        }
    }
    // If block leaves the platform space (trigger collider) then it will be removed from the block list
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Platform Object")
        {
            platform.RemoveFromList(this.gameObject);
        }
    }
    // If projectile collides with this block it will explode
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Projectile(Clone)")
        {
            Explosion();
        }
    }
    // Explosion Code
    public void Explosion()
    {
        platform.RemoveFromList(this.gameObject);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius); //returns array of colliders inside or touching sphere of area around the block

        foreach (Collider obj in colliders)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            if (obj.gameObject.name == "Air Block")
            {
                currExplosionStrength = lightBlockExplosionStrength;
            }
            else
            {
                currExplosionStrength = explosionStrength;
            }

            if (rb != null)
            {
                rb.AddExplosionForce(currExplosionStrength, explosionPos, explosionRadius, upwardsForce, forceMode);
            }
        }

        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
