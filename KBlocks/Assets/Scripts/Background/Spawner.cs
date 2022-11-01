using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public Vector3 spawnLocation;

    private GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
    private void Start()
    {
        Instantiate(plane, spawnLocation, Quaternion.Euler(0, 90, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Scenery")
        {
            Destroy(other.gameObject);
            Instantiate(plane, spawnLocation, Quaternion.Euler(0, 90, 0));
        }
    }
}
