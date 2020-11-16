using System.Runtime.Versioning;
using System.Diagnostics;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunSettings : MonoBehaviour
{
  

  //audio

    AudioSource audioS;
    
    AudioSource audioReload;
   public AudioClip reloadClipS ;
    
    

    //weapon

    [SerializeField]  private  Animator animator;
    [SerializeField]  private GameObject bulletPrefab;
    [SerializeField]  private GameObject effectPrefab;

    private bool shooting = false;
    [SerializeField]  private float fireRate = 15;
    [SerializeField]  private int reloadTime = 2;
    [SerializeField]  private int damage = 30;

    [SerializeField]  private int maxAmmo = 30;
    private int currentAmmo = 30;

    

    [SerializeField]  private Camera playerCamera;

    

    

    private float nextTimeToFire = 0f;

    private bool isReloading = false;

    // Start is called before the first frame update

   
    void Start()
    {
        currentAmmo = maxAmmo;
        effectPrefab.SetActive(false);
       audioS = gameObject.GetComponent<AudioSource>();
       audioS.PlayOneShot(reloadClipS);
       
    }

    // Update is called once per frame
    void Update()
    {

        if(isReloading) return;
        

        bool leftmouse = Input.GetMouseButton(0);

        if(currentAmmo <= 0 ){
            StartCoroutine(Reload());
            
            return;
        }
        
         if(Input.GetKeyDown(KeyCode.R) ){
            StartCoroutine(Reload());
            return;
        }


       // effectPrefab.SetActive(false);
        if(leftmouse && Time.time >= nextTimeToFire){
           
            nextTimeToFire  = Time.time + 1f/fireRate;
            print("NTF: " + nextTimeToFire);
            currentAmmo--;
              print("Ammo: " + currentAmmo);
            
            if(currentAmmo>=1){

             audioS.Play();
             Shoot();
             
            }else StartCoroutine(Reload());
               


        } 
   

        if(!shooting || !leftmouse ){
             effectPrefab.SetActive(false);
        } 
       
      
    }


    private void Shoot(){
        print("fire");
        shooting = true;
        

        //spawm bullet object
        GameObject bulletObject = Instantiate (bulletPrefab);
        effectPrefab.SetActive(true);
        bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;
        currentAmmo--;
            

           
    }

    IEnumerator Reload(){
        
        shooting = false;

        //audioReload.Start();
        audioS.PlayOneShot(reloadClipS);
        
        isReloading = true;
        print("Reload");

        animator.SetBool("Reloading", true);
    
       yield return new WaitForSeconds(reloadTime);

       animator.SetBool("Reloading", false);
        currentAmmo = 30;
        isReloading = false;
        
        
    }

}
