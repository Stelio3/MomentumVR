using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelBall : MonoBehaviour
{
    Vector3 iniPosition;

    // Start is called before the first frame update
    void Start()
    {
        iniPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = iniPosition;

            GameObject.Find("player").GetComponent<PadelPlayer>().Reset();
        }
    }
}
