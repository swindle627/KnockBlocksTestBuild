using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatorBlock : MonoBehaviour
{
    [Header("Block VFX")]
    public ParticleSystem blockEffect;

    private BlockTracker platform;

    private void Awake()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<BlockTracker>();
    }
    // If block is in the platfom space (trigger collider) then it will be added to the block list
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Platform Object")
        {
            platform.AddToList(this.gameObject);
        }
    }
    // If block leaves the platform space (trigger collider) then it will be removed from the block list
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Platform Object")
        {
            platform.RemoveFromList(this.gameObject);
        }
    }
    // If projectile collides with this block it will detonate all explosion blocks
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            GameObject[] explosionBlocks = GameObject.FindGameObjectsWithTag("Explosion Block");

            foreach(GameObject explosionBlock in explosionBlocks)
            {
                ExplosionBlock block = explosionBlock.GetComponent<ExplosionBlock>();
                block.Explosion();
            }
        }
    }
}
