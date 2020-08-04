using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMoneda : MonoBehaviour
{
    [SerializeField]
    private VerticalMovement verticalMov;
    private void OnCollisionEnter(Collision collision)
    {
        verticalMov.subiendo = false;
        verticalMov.bajando = true;
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        verticalMov.subiendo = false;
        verticalMov.bajando = true;
        Destroy(this.gameObject);
    }
}
