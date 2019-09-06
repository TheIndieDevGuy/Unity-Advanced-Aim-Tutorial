/*
 * Created on Fri Sep 06 2019
 *
 *  The Indie Dev Guy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour

{
    [SerializeField] float speed=5,jump=4;
    float xr,yr;
    [SerializeField] Transform Cam;
    [SerializeField] Transform ShootingPose;
    [SerializeField] GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState=CursorLockMode.Locked;
       Cursor.visible=false; 
    }

    // Update is called once per frame
    void Update()
    {
         // movement
        {
       float x=Input.GetAxis("Horizontal")*Time.deltaTime*speed;
       float y=Input.GetAxis("Vertical")*Time.deltaTime*speed;

       transform.Translate(new Vector3(x,0,y));

       if(Input.GetKeyDown(KeyCode.Space)
       &&Physics.Raycast(transform.position, -Vector3.up, (1.75f/2))
       ){
           GetComponent<Rigidbody>().AddForce(Vector3.up*jump,ForceMode.VelocityChange);
       }
       xr-=Input.GetAxis("Mouse Y")*2;
       xr=Mathf.Clamp(xr,-90,90);
       yr+=Input.GetAxis("Mouse X")*2;
       
       Cam.localRotation=Quaternion.Euler(xr,0,0);
       transform.rotation=Quaternion.Euler(0,yr,0);
        }  

        // Aiming and Shooting

            RaycastHit hit;
            if(Physics.Raycast(Cam.position,Cam.forward,out hit ,500)){
                ShootingPose.LookAt(hit.point);

            }
            else{
                ShootingPose.localRotation=Quaternion.identity;
            }


        if(Input.GetMouseButtonDown(0)){

            GameObject Bul=Instantiate(Bullet,ShootingPose.position,ShootingPose.rotation);
            Bul.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*20,ForceMode.Impulse);

        }

    }
}
