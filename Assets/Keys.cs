using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
   
    public static int theKeys;
    public Text textKeys;
    void Start()
    {
        
        textKeys = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    
        textKeys.text = "" + theKeys+"/3";
    }
}
