using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGraund : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Graund")
        GetComponentInParent<PlayerControler>().Graund = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Graund")
            GetComponentInParent<PlayerControler>().Graund = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
