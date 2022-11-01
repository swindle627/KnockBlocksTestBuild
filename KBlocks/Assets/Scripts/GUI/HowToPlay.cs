using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject[] pages;
    private int pageNumber = 0;

    public void NextPage()
    {
        pages[pageNumber].SetActive(false);

        if(pageNumber + 1 != pages.Length)
        {
            pageNumber++;
            pages[pageNumber].SetActive(true);
        }
        else
        {
            pageNumber = 0;
            pages[pageNumber].SetActive(true);
        }
    }
}
