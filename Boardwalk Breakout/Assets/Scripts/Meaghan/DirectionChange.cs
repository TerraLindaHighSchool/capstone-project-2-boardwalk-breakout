using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    [Header("Direction")]
    [SerializeField]
    bool forward;
    [SerializeField]
    bool backward;
    [SerializeField]
    bool left;
    [SerializeField]
    bool right;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Push>() != null)
        {
            other.gameObject.GetComponent<Push>().setAllDirectionsFalse();
            if (forward)
                other.gameObject.GetComponent<Push>().forward = true;
            if (backward)
                other.gameObject.GetComponent<Push>().backward = true;
            if (left)
                other.gameObject.GetComponent<Push>().left = true;
            if(right)
                other.gameObject.GetComponent<Push>().right = true;
        }
    }


}
