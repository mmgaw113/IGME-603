using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    public static bool gameispaused = false;
    public GameObject pausemenuui;
     

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameispaused)
            {
                resume();
            }
            else
            {
                pause();
                    }
        }

    }
    public void resume()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }

    void pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }

    public void quitgame()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menuscene");
    }
}
