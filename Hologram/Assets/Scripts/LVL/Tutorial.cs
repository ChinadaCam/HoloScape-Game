using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject UI;   //creates G.O
    public GameObject UI2 = null;   //creates G.O


    private void Start()
    {
        UI.SetActive(false); //deactivate on start
        UI2.SetActive(false);
    }



    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))  //activate 
        {
            UI.SetActive(true);
            UI2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) //deactivate
    {

        UI.SetActive(false);
        UI2.SetActive(false);
    }





}
