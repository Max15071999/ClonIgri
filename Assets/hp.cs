using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public static float theHelth=100;
    public Text textHealth;
    void Start()
    {
        textHealth = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textHealth.text = "" +  theHelth + "%" ;
    }
}


