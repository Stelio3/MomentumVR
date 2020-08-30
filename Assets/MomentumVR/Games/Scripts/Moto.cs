using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moto : MonoBehaviour
{
    private Vector3 direction, velocity;
    private float leftRotation, rightRotation;

    public GameObject leftHand, rightHand, eje;
    
    [SerializeField]
    float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        leftRotation = leftHand.transform.rotation.x;
        rightRotation = rightHand.transform.rotation.x;
        moveSpeed += leftRotation*0.1f + rightRotation * 0.1f;

        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
}
