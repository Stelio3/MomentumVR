﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelGame : MonoBehaviour
{
    private Rigidbody rBody;
    public GameObject rHand, lHand;
    public float ballForce;

    // Start is called before the first frame update
    void Start()
    {
        rBody.AddForce(transform.forward * ballForce);
        rBody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rHand || other.gameObject == lHand)
        {
            rBody.AddForce(transform.forward * ballForce);
            
        }
    }
}
