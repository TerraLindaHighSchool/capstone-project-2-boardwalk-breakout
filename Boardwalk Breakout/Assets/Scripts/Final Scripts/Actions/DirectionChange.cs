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
        if(other.GetComponent<Push>() != null)
        {
            other.GetComponent<Push>().setAllDirectionsFalse();
            if (forward)
                other.GetComponent<Push>().forward = true;
            if (backward)
                other.GetComponent<Push>().backward = true;
            if (left)
                other.GetComponent<Push>().left = true;
            if(right)
                other.GetComponent<Push>().right = true;
        }
    }


}
