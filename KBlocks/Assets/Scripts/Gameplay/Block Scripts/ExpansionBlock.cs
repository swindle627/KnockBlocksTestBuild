using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionBlock : MonoBehaviour
{
    [Header("Block VFX")]
    public ParticleSystem blockEffect;

    [Header("Expansion Settings")]
    public float targetScale;
    public float growSpeed;

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
    // when hit this block will grow
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            while (transform.localScale != new Vector3(targetScale, targetScale, targetScale))
            {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * growSpeed);
            }

            Instantiate(blockEffect, collision.transform.position, Quaternion.identity);
        }
    }
}
