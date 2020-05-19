using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun1 : MonoBehaviour
{
    private bool played;

    public ParticleSystem particleLauncher;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            played = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            played = false;
    }




    // Update is called once per frame
    void Update()
    {
        if (played)
        {
            if (Input.GetKeyDown(KeyCode.E))
                particleLauncher.Play();


            if (Input.GetKeyUp(KeyCode.E))
                particleLauncher.Stop();
        }
    }




}
