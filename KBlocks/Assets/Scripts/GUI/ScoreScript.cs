using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [Header("Level List")]
    public List<GameObject> levels;

    private int[] starCount;
    private float[] scores;

    // Start is called before the first frame update. High scores and highest stars earned for each level are made visable on the icon for each level
    void Start()
    {
        starCount = new int[5];
        scores = new float[5];

        DefaultValues();
        LoadValues();

        int index = 0;

        foreach(GameObject go in levels)
        {
            // sets stars for every level
            GameObject goStar = go.transform.GetChild(1).gameObject;
            GameObject starOne = goStar.transform.GetChild(0).gameObject;
            GameObject starTwo = goStar.transform.GetChild(1).gameObject;
            GameObject starThree = goStar.transform.GetChild(2).gameObject;

            if(starCount[index] == 0)
            {
                starOne.SetActive(false);
                starTwo.SetActive(false);
                starThree.SetActive(false);
            }
            else if(starCount[index] == 1)
            {
                starTwo.SetActive(false);
                starThree.SetActive(false);
            }
            else if(starCount[index] == 2)
            {
                starThree.SetActive(false);
            }

            // sets score for every level
            GameObject goPoints = go.transform.GetChild(2).gameObject;
            TextMeshProUGUI scoreText = goPoints.GetComponent<TextMeshProUGUI>();
            scoreText.text = scores[index].ToString();

            index++;
        }

        int counter = 0;

        foreach(GameObject level in levels)
        {
            if(counter >= DataList.levelsUnlocked)
            {
                level.SetActive(false);
            }

            counter++;
        }
    }

    // Sets default score and star value to zero. Allows unplayed levels to have 0 for score and stars
    private void DefaultValues()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
            starCount[i] = 0;
        }
    }

    // Loads in saved score and star values
    private void LoadValues()
    {
        SavaData data = SaveToFile.Load();

        if(data != null)
        {
            int index = 0;

            foreach (float score in data.levelScores)
            {
                scores[index] = score;
                index++;
            }

            index = 0;

            foreach (int stars in data.levelStarCount)
            {
                starCount[index] = stars;
                index++;
            }

            DataList.levelScores = data.levelScores;
            DataList.levelStarCount = data.levelStarCount;
            DataList.levelsUnlocked = data.levelsUnlocked;
        }
    }


}
