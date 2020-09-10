using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelGame : MonoBehaviour
{
    public float velInicial = 30f;
    public GameObject rHand, lHand;
    public Rigidbody rBody;
    Vector3 posInicial;

    bool jugando;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    public void Reset()
    {
        transform.position = posInicial;
        jugando = false;
        DetenerMov();
    }

    public void DetenerMov()
    {
        rBody.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jugando && rHand)
        {
            jugando = true;
            rBody.AddForce(new Vector3(velInicial, velInicial, velInicial));
        }
    }
}
