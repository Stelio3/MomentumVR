using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Moto.Instance.Grab(gameObject, true);
    }
    private void OnTriggerExit(Collider other)
    {
        Moto.Instance.Grab(gameObject, false);
    }

}
