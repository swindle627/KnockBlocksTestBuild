using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Level Number (0 based, EX: Level 1 = 0")]
    public int level;

    [Header("Level Settings")]
    public float oneStarReq;
    public float twoStarReq;
    public float threeStarReq;
    public float goldBlockValue = 1000;
    public float bonusPoints;
    public int ammoLimit;

    [Header("Environments")]
    public GameObject[] environments;

    private int ammoUsed = 0;
    private float penaltyMultiplier = 1.00f;
    private bool endLevel = false;
    private float totalPoints;
    private float blockPoints;
    private GameObject gameOverWindow;
    private GameObject starOne, starTwo, starThree;
    private GameObject bonusPointsText, blockPointsText, totalPointsText, targetPointText, ammoBonusText;
    private GameObject cam;
    private BlockTracker platform;
    private int starCount = 0;
    private bool ranOnce = false;
    private int ammoBonus;

    private void Start()
    {
        platform = GameObject.Find("Platform").GetComponent<BlockTracker>();
        gameOverWindow = GameObject.Find("Game Over Window");
        starOne = GameObject.Find("Star 1");
        starTwo = GameObject.Find("Star 2");
        starThree = GameObject.Find("Star 3");
        blockPointsText = GameObject.Find("Block Points");
        bonusPointsText = GameObject.Find("Bonus Points");
        totalPointsText = GameObject.Find("Total");
        targetPointText = GameObject.Find("Target Score");
        ammoBonusText = GameObject.Find("Ammo Bonus");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        starOne.SetActive(false);
        starTwo.SetActive(false);
        starThree.SetActive(false);
        gameOverWindow.SetActive(false); // GameObject.Find does not work on inactive objects so gameOverWindow must be active at start and then deacttivated
        targetPointText.GetComponent<TextMeshProUGUI>().text = "Target: " + oneStarReq;
        ammoBonus = ammoLimit;
        ammoBonusText.GetComponent<TextMeshProUGUI>().text = "Ammo Bonus: " + ammoBonus;

        // Environment names must be the same as what they are called in EnvironmentManager
        foreach(GameObject go in environments)
        {
            if(EnvironmentManager.selectedEnvironment == go.name)
            {
                Instantiate(go, Vector3.zero, Quaternion.identity);
                break;
            }
        }
    }
    private void Update()
    {
        StartCoroutine(Delay(0.1f));

        if(endLevel)
        {
            if(!ranOnce)
            {
                CaluculateScore();
                ranOnce = true;
            }
        }
    }
    // ensures that the blocklist is counted after the blocks have been put in it
    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        endLevel = platform.CountBlocks();
    }
    //counts the amount of ammo used and adds to penalty if necessary
    public void CountAmmo()
    {
        ammoUsed++;

        if(ammoUsed > ammoLimit)
        {
            penaltyMultiplier -= 0.02f;
            penaltyMultiplier = (float)Math.Round(penaltyMultiplier, 2);
        }

        if(ammoBonus > 0)
        {
            ammoBonus--;
            ammoBonusText.GetComponent<TextMeshProUGUI>().text = "Ammo Bonus: " + ammoBonus;
        }
    }
    // if endLevel = true this will calculate the player score. Score will be 0 if all gold blocks are kncoked off. Data for the level will be saved
    public void CaluculateScore()
    {
        float goldBlockCount = platform.CountGoldBlocks();
        if(goldBlockCount == 0f)
        {
            blockPoints = 0;
            bonusPoints = 0;
            totalPoints = 0;
        }
        else
        {
            blockPoints = goldBlockCount * goldBlockValue;
            bonusPoints = bonusPoints * penaltyMultiplier;
            bonusPoints = Mathf.Round(bonusPoints);
            totalPoints = Mathf.Round(blockPoints + bonusPoints);
        }

        DisplayScore();
        DataList.AddScore(totalPoints, starCount, level);
        SaveToFile.Save();
    }
    // displays the points and stars on game over screen
    public void DisplayScore()
    {
        gameOverWindow.SetActive(true);
        cam.GetComponent<ShootAtClickPosition>().enabled = false;
        
        if(totalPoints >= threeStarReq)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(true);
            starCount = 3;
        }
        else if(totalPoints >= twoStarReq)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starCount = 2;
        }
        else if(totalPoints >= oneStarReq)
        {
            starOne.SetActive(true);
            starCount = 1;
        }

        blockPointsText.GetComponent<TextMeshProUGUI>().text = "Block Points: " + blockPoints.ToString();
        bonusPointsText.GetComponent<TextMeshProUGUI>().text = "Bonus Points: " + bonusPoints.ToString();
        totalPointsText.GetComponent<TextMeshProUGUI>().text = "Total Points: " + totalPoints.ToString();
    }
}
