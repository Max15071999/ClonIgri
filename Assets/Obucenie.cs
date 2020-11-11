using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obucenie : MonoBehaviour
{
    public GameObject Instruction;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obuci")
        {
            Instruction.SetActive(true);


        }
        if (other.tag == "Door")

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Obuci")

        {
            Instruction.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
        {

        }
    }

