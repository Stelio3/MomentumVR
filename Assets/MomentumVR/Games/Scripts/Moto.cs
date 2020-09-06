using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moto : Singleton<Moto>
{
    private float leftRotation, rightRotation;

    public static bool leftGrab, rightGrab;
    public GameObject leftHand, rightHand;
    [SerializeField]
    float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        if (rightGrab || leftGrab || Input.GetKey("a") || Input.GetKey("d"))
        {
            if ((rightGrab && !leftGrab) ||(Input.GetKey("a") && !Input.GetKey("d")))
            {
                transform.Rotate(0, 30f * Time.deltaTime, 0, Space.Self);
            }
            else if ((!rightGrab && leftGrab) || (!Input.GetKey("a") && Input.GetKey("d")))
            {
                transform.Rotate(0, -30f * Time.deltaTime, 0, Space.Self);
            }
            leftRotation = leftHand.transform.localRotation.x;
            rightRotation = rightHand.transform.localRotation.x;

            moveSpeed += leftRotation * 0.1f + rightRotation * 0.1f;

            transform.localPosition += -transform.right * moveSpeed * Time.deltaTime;
            Debug.Log("LeftRotation: " + leftRotation + " RightRotation: " + rightRotation);
        }
    }
    public void Grab(GameObject go, bool value)
    {
        if (go.tag == "Right")
        {
            rightGrab = value;
        }
        else if (go.tag == "Left")
        {
            leftGrab = value;
        }
    }
}
