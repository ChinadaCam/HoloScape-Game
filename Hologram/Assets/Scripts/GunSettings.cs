using System.Diagnostics;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunSettings : MonoBehaviour
{
    [SerializeField]  private  Animator animator;
    [SerializeField]  private GameObject bulletPrefab;
    [SerializeField]  private Camera playerCamera;

    [SerializeField]  private int maxAmmo = 30;
    [SerializeField]  private int currentAmmo = 30;

    [SerializeField]  private float fireRate = 15;
    [SerializeField]  private int reloadTime = 2;
    [SerializeField]  private int damage = 30;

    private float nextTimeToFire = 0f;

    private bool isReloading = false;

    // Start is called before the first frame update

   
    void Start()
    {
        currentAmmo = maxAmmo;
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



        if(leftmouse && Time.time >= nextTimeToFire){
           
            nextTimeToFire  = Time.time + 1f/fireRate;
            print("NTF: " + nextTimeToFire);
            currentAmmo--;
              print("Ammo: " + currentAmmo);
            
            if(currentAmmo>=1){

             Shoot();
            }else StartCoroutine(Reload());

        }

      
    }


    private void Shoot(){
            print("fire");
            GameObject bulletObject = Instantiate (bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
           currentAmmo--;
            
           
    }

    IEnumerator Reload(){
        isReloading = true;
        print("Reload");

        animator.SetBool("Reloading", true);
    
       yield return new WaitForSeconds(reloadTime);

       animator.SetBool("Reloading", false);
        currentAmmo = 30;
        isReloading = false;
    }

}
