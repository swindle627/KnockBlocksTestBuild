using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour
{
    [Header("Block VFX")]
    public List<ParticleSystem> blockEffects;

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
    // Triggers visual effects when blocks are hit
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Projectile(Clone)")
        {
            if(gameObject.name == "Air Block")
            {
                Instantiate(blockEffects[0], transform.position, Quaternion.identity);
            }
            else if(gameObject.name == "Iron Block")
            {
                Instantiate(blockEffects[1], transform.position, Quaternion.identity);
            }
            else if(gameObject.name == "Gold Block")
            {
                Instantiate(blockEffects[2], transform.position, Quaternion.identity);
            }
        }
    }
}
