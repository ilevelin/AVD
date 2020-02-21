using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(3);
    }

}


