using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colect : MonoBehaviour
{
    public static int theCoins;
    public Text textCoins;
    void Start()
    {
        textCoins = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textCoins.text = "" + theCoins;
    }
}
