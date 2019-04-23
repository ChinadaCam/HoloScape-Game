
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [Header("Pause Menu")]
    [Space]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused=false;




    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Cursor.visible = true;
            ActiveMenu();
         

        }
        else
        {
            Cursor.visible = false;
            DeactivateMenu();
            
        }

	}
     void ActiveMenu()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);


    }

    void DeactivateMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;


    }

    public void Resume()
    {
        isPaused = !isPaused;

       
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void OptionsMenu()
    {
        Debug.Log("OptionsMenu");
    }

    public void LoadMenu()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }


}
