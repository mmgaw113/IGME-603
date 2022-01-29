using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    // For loading screen
    //public GameObject loadingscreen;
    //public Slider slider;


    public void playgame()
    {
        SceneManager.LoadScene("PlayerSetup");
    }

    public void quitgame()
    {
        Application.Quit();
    }


    // for loading screen

    /*public void Loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }*/

    /*IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
        }
        yield return null;
    }*/
   
    
}
