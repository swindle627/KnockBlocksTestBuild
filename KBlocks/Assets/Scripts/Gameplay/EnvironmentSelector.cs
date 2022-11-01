using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSelector : MonoBehaviour
{
    [Header("Environment buttons")]
    public GameObject blueSky;
    public GameObject space;
    // Start is called before the first frame update
    void Start()
    {
        if(EnvironmentManager.environmentsUnlocked["BlueSky"].Equals(true))
        {
            blueSky.SetActive(true);
        }
        if(EnvironmentManager.environmentsUnlocked["Space"].Equals(true))
        {
            space.SetActive(true);
        }

        // Name buttons "BlueSky" and "Space"
        GameObject.Find(EnvironmentManager.selectedEnvironment).GetComponent<Image>().color = new Color(0.4f, 0.35f, 1);
    }
    // BlueSky or Space
    public void SetEnvironment(string name)
    {
        GameObject.Find(EnvironmentManager.selectedEnvironment).GetComponent<Image>().color = new Color(0.2971698f, 0.7021798f, 1);
        DataList.environmentSelected = name;
        EnvironmentManager.selectedEnvironment = name;
        GameObject.Find(EnvironmentManager.selectedEnvironment).GetComponent<Image>().color = new Color(0.4f, 0.35f, 1);
    }
    public void SaveEnvironment()
    {
        SaveToFile.Save();
    }
}
