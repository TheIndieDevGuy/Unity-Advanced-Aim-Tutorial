/*
 * Created on Fri Sep 06 2019
 *
 *  The Indie Dev Guy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("Die",4); 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,1f)){
            // what happens when whe hit something 

            transform.position=hit.point;
            GetComponent<Rigidbody>().isKinematic=true;


        }

    }
    void Die(){
        Destroy(gameObject);
    }
}
