using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    public GameObject doorHinge;
    public GameObject target;
    public float time = 5f;
    public GameObject[] plushies;
    public static GameObject player { get; set; }

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
        if (time < 0)
        {
            target.GetComponent<Rigidbody>().isKinematic = false;
            doorHinge.transform.localRotation = Quaternion.Slerp(doorHinge.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 2);
            WinLose.currentEvent = 2;
        }
        else if (played)
        {
            if (Input.GetKeyDown(KeyCode.E))
                particleLauncher.Play();
            if (Input.GetKey(KeyCode.E))
                time -= Time.deltaTime;
        }
        else
            Stay();
        if (Input.GetKeyUp(KeyCode.E))
            particleLauncher.Stop();

    }

    private void Stay()
    {
        foreach (GameObject plushie in plushies)
            plushie.GetComponent<FollowCommand>().enabled = false;
    }

}


