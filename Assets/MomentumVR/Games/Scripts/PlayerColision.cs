using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    // Update is called once per frame
    private bool colisioned = false;
    private AudioSource audioSource;

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
        if (!colisioned && other.gameObject.tag == "Ball")
        {
            audioSource.Play();
            ScreenManager.Instance.points += 1;
            colisioned = true;
            Destroy(other.gameObject);
        }
    }
}
