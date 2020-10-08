using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    public int healts;
    public int numberOfLives;

    public Image[] lives;
    public Sprite fullLive;
    public Sprite emptyLives;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healts > numberOfLives)
        {
            healts = numberOfLives;
        }


        for (int i = 0; i <lives.Length; i++)
        {
            if (i<healts)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLives;
            }




            if (i<numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
