using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfectionRate : MonoBehaviour
{
    public float rate = 0.5f;
    public float currentInfection = 1;
    //public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInfection < 100)
        {
            currentInfection += rate * Time.deltaTime;
            //text.text = "Inefection: " + Mathf.Round(currentInfection) + "%";
        }
        else
        {
            SceneManager.LoadScene("MenuScene 1");
        }
    }
}
