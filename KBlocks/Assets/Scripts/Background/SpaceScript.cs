using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    public Material spaceSkybox;

    private void Start()
    {
        RenderSettings.skybox = spaceSkybox;
    }
}
