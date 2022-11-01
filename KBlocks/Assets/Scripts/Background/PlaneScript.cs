using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * 40 * Time.deltaTime);
    }
}
