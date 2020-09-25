using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    // Update is called once per frame
    private bool colisioned = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
            Destroy(gameObject);
            ScreenManager.Instance.points += 1;
            colisioned = true;
            GameManager.GetInstance().points += 10;
        }
    }
}
 