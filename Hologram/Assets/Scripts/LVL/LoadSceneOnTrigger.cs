using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour {

    [SerializeField] public string LevelToLoad;


     

     void OnTriggerStay(Collider other)
    {
        Debug.LogError("detected");
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(LevelToLoad);
            Debug.LogError("Load");
        }
    }

}
