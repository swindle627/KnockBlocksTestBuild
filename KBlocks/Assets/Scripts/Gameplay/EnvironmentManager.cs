using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnvironmentManager 
{
    public static Hashtable environmentsUnlocked = new Hashtable();
    public static string selectedEnvironment;
    
    public static void CreateTable()
    {
        environmentsUnlocked.Add("BlueSky", true);
        environmentsUnlocked.Add("Space", false);
    }
    public static void CheckUnlocks()
    {
        SavaData data = SaveToFile.Load();
        
        if(data != null)
        {
            if (data.totalStarCount <= 6)
            {
                environmentsUnlocked["Space"] = true;
            }
        }
    }
    // Just used for start up to initialize selected environment
    public static void InitializeSelectedEnvironment()
    {
        SavaData data = SaveToFile.Load();
        if(data == null)
        {
            selectedEnvironment = "BlueSky";
        }
        else
        {
            selectedEnvironment = data.environmentSelected;
        }
    }
}
