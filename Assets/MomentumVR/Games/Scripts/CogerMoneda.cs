using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMoneda : MonoBehaviour
{
    [SerializeField]
    private VerticalMovement verticalMov;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        verticalMov.subiendo = false;
        verticalMov.bajando = true;
        audioSource.Play();
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        verticalMov.subiendo = false;
        verticalMov.bajando = true;
        audioSource.Play();
        Destroy(this.gameObject);
    }
}
