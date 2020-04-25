using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntroButton : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        StartCoroutine(LoadIntroScene());
    }

    private IEnumerator LoadIntroScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Final Asigment/Scenes/IntroScene");
    }

}