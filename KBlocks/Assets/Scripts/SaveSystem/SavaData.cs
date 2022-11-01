using System;
using System.Collections.Generic;

[Serializable]
// monobehavior is not serializable 
public class SavaData 
{
    public float[] levelScores;
    public int[] levelStarCount;
    public int levelsUnlocked;
    public int totalStarCount;
    public string environmentSelected;

    // Lists of data from DataList are sent here to be serialized. This script is only called by SaveToFile
    public SavaData()
    {
        levelScores = DataList.levelScores;
        levelStarCount = DataList.levelStarCount;
        levelsUnlocked = DataList.levelsUnlocked;
        totalStarCount = DataList.totalStarCount;
        environmentSelected = DataList.environmentSelected;
    }
}
