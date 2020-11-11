using System.Runtime.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTimer;
    public float lifeTime = 8f;
    public float speed = 25f;
    
  
    void Start(){
        lifeTimer = lifeTime;
    }
 

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward * speed * Time.deltaTime;
       
       lifeTimer -= Time.deltaTime;
       if(lifeTimer<=0){
           Destroy(gameObject);
       }

    }
}
