using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Coño");
        StartCoroutine(ActiveCoin());
        ScreenManager.Instance.points += 1;
        //Añadir tiempo
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Coño");
        StartCoroutine(ActiveCoin());
        ScreenManager.Instance.points += 1;
        //Añadir tiempo
    }
    IEnumerator ActiveCoin()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(true);
    }
}
