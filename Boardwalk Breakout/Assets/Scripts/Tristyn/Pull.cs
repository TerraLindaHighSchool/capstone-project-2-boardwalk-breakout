using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    //This isn't working

    private List<GameObject> pullObjects;
    public Vector3 pullDirection;
    public float pullSpeed;
    void Start()
    {
        pullObjects = new List<GameObject>();
    }

    void Update()
    {
        pullDirection = new Vector3(0, 0, -10);
        foreach (GameObject obj in pullObjects)
        {
            obj.transform.Translate(Time.deltaTime * pullSpeed * pullDirection, transform);

        }
    }

    public void OnTriggerEnter(Collider col)
    {
        pullObjects.Add(col.gameObject);
    }


    public void OnTriggerExit(Collider col)
    {
        pullObjects.Remove(col.gameObject);
    }
}
