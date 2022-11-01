using System.Collections.Generic;
using UnityEngine;

public class GeneratorBlock : MonoBehaviour
{
    [Header("Generator Settings")]
    public List<GameObject> blockList;
    public Vector3 spawnArea;
    public int spawnCount;

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
    // If projectile collides with this block it will spawn random blocks from the blockList in the spawn area
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Projectile(Clone)")
        {
            int count = 0;

            while(count < spawnCount)
            {
                Vector3 pos = new Vector3(UnityEngine.Random.Range(-spawnArea.x , spawnArea.x ), spawnArea.y, UnityEngine.Random.Range(-spawnArea.z , spawnArea.z ));
                GameObject block = Instantiate(blockList[UnityEngine.Random.Range(0, blockList.Count)], pos, Random.rotation);
                block.name = block.name.Replace("(Clone)", "");
                count++;
            }
        }
    }
}
