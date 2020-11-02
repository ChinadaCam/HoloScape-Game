using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetection : MonoBehaviour {
    [Header("UI")]
    //creates G.O
    public GameObject UI; //
    public GameObject UI2 ;  //
    [Space]

    [Header ("Level")]
    public GameObject ChangeLvlTrigger;   //change lvl
    public GameObject Beam;   
    [Space]
    [Header("Animation")]
   public Animator Anim; //button animation

    private void Start()
    {
        UI.SetActive(false); //deactivate on start
        UI2.SetActive(false);
        ChangeLvlTrigger.SetActive(false);
        Animator Anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            UI.SetActive(true);
            
            UI2.SetActive(true);
            
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //se tiver a key consegue usar senao mostra UI que precisa
            Debug.Log("pressed");
            ChangeLvlTrigger.SetActive(true);
            Beam.SetActive(true);
            Anim.Play("ButtonPress");
          
        }
    }

    private void OnTriggerExit(Collider other)
    {

        UI.SetActive(false);
        UI2.SetActive(false);
    }
}
