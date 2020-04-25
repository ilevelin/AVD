using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModController : MonoBehaviour
{

    private int charges = 0;
    private bool modified = true;
    public GameObject[] images;
    
    void Update()
    {
        if (modified) for (int i = 0; i < images.Length; i++)
        {
            if (i < charges) images[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            else images[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    public bool UseCharge()
    {
        charges--;
        if (charges < 0)
        {
            charges = 0;
            return false;
        }
        else
        {
            modified = true;
            return true;
        }
    }

    public void AddCharge()
    {
        charges++;
        modified = true;
    }
}
