using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfectionRate : MonoBehaviour
{
    public float rate = 0.5f;
    public float currentInfection = 1;
    public TextMeshProUGUI text;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //text= GameObject.Find("HealthUI").GetComponent<TextMeshProUGUI>();
        slider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
        Debug.Log("Slider: " + slider);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInfection < 100)
        {
            currentInfection += rate * Time.deltaTime;
            slider.value = currentInfection;
            //text.text = "Inefection: " + Mathf.Round(currentInfection) + "%";
        }
        else
        {
            SceneManager.LoadScene("MenuScene 1");
        }
    }
}
