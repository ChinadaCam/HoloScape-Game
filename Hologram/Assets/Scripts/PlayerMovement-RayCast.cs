using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour {
    public Camera cam;
    public bool NavMesh = true;
    
    public NavMeshAgent agent;



    void Update()
    {
        if (NavMesh == true)
        {

      
        if (Input.GetMouseButtonDown(0)) //raycast
        {

                if (EventSystem.current.IsPointerOverGameObject()) //check if clicked on UI
                    return;


            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //get mouse pos
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit)) //CHECK IF CLICKED IN GROUND
            {
                agent.SetDestination(hit.point);
            }
        }
       }
    }
}