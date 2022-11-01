using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class DataList 
{
    public static float[] levelScores = new float[5];
    public static int[] levelStarCount = new int[5];
    public static int levelsUnlocked = 1;
    public static int totalStarCount = 0;
    public static string environmentSelected = "BlueSky";
    
    // Adds highscores and highest stars earned for each level to arrays so they can be accessed and saved 
    public static void AddScore(float score, int stars, int level)
    {
        bool redo = false;

        // Checks to see if a previously unlocked level is being redone
        if (levelScores[level] != 0)
        {
            redo = true;
        }

        // If the player gets a new highscore the previous score and stars are replaced
        if (levelScores[level] < score)
        {
            levelScores[level] = score;
            levelStarCount[level] = stars;
        }

        // If player earned at least 1 star and this isn't a previous level being redone a new level is unlacked
        if (stars != 0 && !redo && levelsUnlocked != 5)
        {
            levelsUnlocked++;
        }

        totalStarCount = 0;

        foreach(int i in levelStarCount)
        {
            totalStarCount += i;
        }
    }
    public static void SelectEnvironment(string name)
    {
        environmentSelected = name;
    }
}
