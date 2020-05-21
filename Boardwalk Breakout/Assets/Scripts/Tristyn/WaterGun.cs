using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{

    //public ParticleSystem particleLauncher;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("YAY");
        }

    }









    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("COLLISION");
        }
    }*/





    /*

    // Update is called once per frame
     void Update()
     {
         if (Input.GetKeyDown(KeyCode.E))
         {
             particleLauncher.Play();
         }

         if (Input.GetKeyUp(KeyCode.E))
         {
             particleLauncher.Stop();
         }
     }*/



}
