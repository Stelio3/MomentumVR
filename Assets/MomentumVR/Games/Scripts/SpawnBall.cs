using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject myZone;

    private GameObject newBall;
    private bool colisioned = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!colisioned && other.gameObject == myZone)
        {
            newBall = gameObject;
            colisioned = true;
            Destroy(gameObject);
            Destroy(other.gameObject);
            CrossedArms.Instance.Spanw(newBall, myZone);
            ScreenManager.Instance.points += 1;
        }
        else if (!colisioned)
        {
            ScreenManager.Instance.points -= 1;
            colisioned = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        colisioned = false;
    }
}
