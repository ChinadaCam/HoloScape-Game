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
    [Space]
    [Header("Animation")]
   public Animator Anim;

    private void Start()
    {
        UI.SetActive(false); //deactivate on start
        UI2.SetActive(false);
        ChangeLvlTrigger.SetActive(false);
        Animator Anim = GetComponent<Animator>();
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("pressed");
            UI.SetActive(true);
            
            UI2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeLvlTrigger.SetActive(true);
                Anim.Play("ButtonPress");
                Debug.Log("pressed");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {

        UI.SetActive(false);
        UI2.SetActive(false);
    }
}
