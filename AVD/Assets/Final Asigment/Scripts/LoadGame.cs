﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
