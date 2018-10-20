using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFade : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;


    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float time = 1f;
        //Animate fade
        while (time > 0f)
        {
            float a = curve.Evaluate(time);
            img.color = new Color(0f, 0f, 0f, time);

            time -= Time.deltaTime*2f;
            yield return 0;
        }
        //Load scene
    }


}
