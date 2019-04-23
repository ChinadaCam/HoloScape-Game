
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {


    // n ta a ser usado

    public LoadSceneMode load;

    public void Select(string levelName)
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
