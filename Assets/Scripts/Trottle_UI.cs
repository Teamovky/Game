using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trottle_UI : MonoBehaviour
{
    public Text Trottle_ui;
    public Playermovement trottle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Trottle_ui.text = (Mathf.Round((trottle.thrust +10f) * (100f - 0f) / (10f +10f) + 0f)).ToString();
    }
}