using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    // Update is called once per frame
    private bool colisioned = false;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!colisioned)
        {
            Destroy(gameObject);
            ScreenManager.Instance.points += 1;
            colisioned = true;
            GameManager.GetInstance().points += 10;
        }
    }
}
 