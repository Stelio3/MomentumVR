using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoGrab : OVRGrabbable
{
    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            Moto.Instance.Grab(gameObject, true);
        }
        else
        {
            Moto.Instance.Grab(gameObject, false);
        }
    }
    
}
