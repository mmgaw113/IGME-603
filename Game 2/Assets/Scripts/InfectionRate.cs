using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfectionRate : MonoBehaviour
{
    public float rate = 3f;
    public float currentInfection = 1;
    public TextMeshProUGUI text;
    public SpriteRenderer spriteRenderer;
    public Gradient gradient;
    public float value;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        text= GameObject.Find("HealthUI").GetComponent<TextMeshProUGUI>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Lerp(0f, 1f, t);
        t = currentInfection * 0.01f;
        spriteRenderer.color = gradient.Evaluate(value);
        if (currentInfection < 100)
        {
            currentInfection += rate * Time.deltaTime;
            text.text = "Inefection: " + Mathf.Round(currentInfection) + "%";
        }
        else
        {
            SceneManager.LoadScene("Game Over");
        }

    }
}
