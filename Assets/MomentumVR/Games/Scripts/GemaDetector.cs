using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaDetector : MonoBehaviour
{
    // Update is called once per frame
    private bool colisioned = false;
    private AudioSource audioSource;
    public GameObject go;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!colisioned)
        {
            audioSource.Play();
            ScreenManager.Instance.points += 1;
            colisioned = true;
            go.SetActive(false);
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
 