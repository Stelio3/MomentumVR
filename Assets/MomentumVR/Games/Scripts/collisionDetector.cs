using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        ScreenManager.Instance.points += 10;
        GameManager.GetInstance().points += 10;
        Destroy(this.gameObject);
    }
}
 