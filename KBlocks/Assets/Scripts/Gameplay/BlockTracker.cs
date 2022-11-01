using System.Collections.Generic;
using UnityEngine;

public class BlockTracker : MonoBehaviour
{
    [Header("Required Objects")]
    private List<GameObject> blockList = new List<GameObject>(); // List of blocks that are in the platform space

    // Checks the tags of all the blocks in blockList and if only gold blocks remain or no gold blocks remain it ends the game
    public bool CountBlocks()
    {
        bool endLevel = false;
        bool onlyGold = true;
        int countGolds = 0;

        foreach(GameObject block in blockList)
        {
            if(block.tag == "Gold Block")
            {
                countGolds++;
            }
            else
            {
                onlyGold = false;
            }
        }

        if(countGolds == 0)
        {
            endLevel = true; // Level will end if there are no gold blocks left
        }
        else if(onlyGold == true)
        {
            endLevel = true; // Level will end if there are only gold blocks left
        }

        return endLevel;
    }
    // Counts how many gold blocks remain and returns the count
    public float CountGoldBlocks()
    {
        float countGolds = 0;

        foreach(GameObject block in blockList)
        {
            if(block.tag == "Gold Block")
            {
                countGolds++;
            }
        }

        return countGolds;
    }
    // Adds a block to the block list
    public void AddToList(GameObject block)
    {
        blockList.Add(block);
    }
    // Removes a block from the block list
    public void RemoveFromList(GameObject block)
    {
        blockList.Remove(block);
    }
}
