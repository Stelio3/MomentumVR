using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelPlayer : MonoBehaviour
{
    public Transform aimTarget;
    public Transform ball;
    float force = 18;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 12, 0);

            ball.GetComponent<PadelBall>().hitter = "player";
            ball.GetComponent<PadelBall>().playing = true;
        }
    }
}

