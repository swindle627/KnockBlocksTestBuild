using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private void Start()
    {
        if(EnvironmentManager.environmentsUnlocked.Count == 0)
        {
            EnvironmentManager.CreateTable();
        }
        EnvironmentManager.CheckUnlocks();
        EnvironmentManager.InitializeSelectedEnvironment();
    }
}
