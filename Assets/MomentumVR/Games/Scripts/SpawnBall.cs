using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject myZone;
    private bool colisioned = false;

    private void Start()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!colisioned && other.gameObject.tag == myZone.tag)
        {
            colisioned = true;
            CrossedArms.Instance.Spanw(gameObject, myZone);
            ScreenManager.Instance.points += 1;
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
